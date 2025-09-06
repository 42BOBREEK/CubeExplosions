using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [Header("ParticleParameters")] 

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    [Header("SpawningParameters")]
    [SerializeField] private int _minCubesSpawned;
    [SerializeField] private int _maxCubesSpawned;
    [SerializeField] private int _neededPercentsChance;
    [SerializeField] private int _maxRandomPercentsChance;
    [SerializeField] private GameObject _cubePrefab;

    private CubeSpawner _newCubeSpawner;

    private void OnMouseUpAsButton()
    {
        SpawnCubes();
    }

    private void SpawnCubes()
    {
        _cubePrefab = gameObject;

        int _ourPercentsChance = Random.Range(0, _maxRandomPercentsChance+1);
        print($"Шансы на разделение: {_ourPercentsChance} должно быть < {_neededPercentsChance}");

        int cubesCount = Random.Range(_minCubesSpawned, _maxCubesSpawned+1);

        if(_ourPercentsChance < _neededPercentsChance)
        {
            for(int i = 0; i < cubesCount; i++)
            {
                GameObject newCube = Instantiate(_cubePrefab, transform.position, transform.rotation);

                _newCubeSpawner = newCube.GetComponent<CubeSpawner>();
        
                _newCubeSpawner._neededPercentsChance = _neededPercentsChance / 2;
                newCube.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2 ); 
            }

            Explode();
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Instantiate(_effect, transform.position, transform.rotation);

        foreach(Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
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
