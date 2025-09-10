using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [Header("ParticleParameters")] 

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    [Header("SpawningParameters")]
    [SerializeField] private PlayerRaycaster _playerRaycaster;
    [SerializeField] private int _minCubesSpawned;
    [SerializeField] private int _maxCubesSpawned;
    [SerializeField] private int _neededPercentsChance;
    [SerializeField] private int _maxRandomPercentsChance;
    [SerializeField] private int _minRandomPercents;
    [SerializeField] private int _smallerVariablesCubeCoefficient;
    [SerializeField] private GameObject _cubePrefab;

    private Cube _newCubeScript;

    private void OnEnable()
    {
        _playerRaycaster.CubeFound += SpawnCubes;
    }

    private void OnDisable()
    {
        _playerRaycaster.CubeFound -= SpawnCubes;
    }

    private void SpawnCubes()
    {
        _cubePrefab = _playerRaycaster.foundCube;

        int _ourPercentsChance = Random.Range(_minRandomPercents, _maxRandomPercentsChance+1);

        int cubesCount = Random.Range(_minCubesSpawned, _maxCubesSpawned+1);

        if(_ourPercentsChance < _cubePrefab.GetComponent<Cube>().neededPercentsChance)
        {
            for(int i = 0; i < cubesCount; i++)
            {
                GameObject newCube = Instantiate(_cubePrefab, _cubePrefab.transform.position, _cubePrefab.transform.rotation);

                _newCubeScript = newCube.GetComponent<Cube>();
        
                _newCubeScript.DecreaseSpawnChances(_smallerVariablesCubeCoefficient);
                newCube.transform.localScale = new Vector3(_cubePrefab.transform.localScale.x / _smallerVariablesCubeCoefficient, _cubePrefab.transform.localScale.y / _smallerVariablesCubeCoefficient, _cubePrefab.transform.localScale.z / _smallerVariablesCubeCoefficient); 
            }

            Explode();
        }

        Destroy(_cubePrefab);
    }

    private void Explode()
    {
        Instantiate(_effect, _cubePrefab.transform.position, _cubePrefab.transform.rotation);

        foreach(Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, _cubePrefab.transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
         Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

         List<Rigidbody> objects = new();
 
         foreach(Collider hit in hits)
             if(hit.attachedRigidbody != null)
                 objects.Add(hit.attachedRigidbody);
         return objects;
     }
}
