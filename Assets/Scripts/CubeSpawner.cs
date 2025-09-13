using UnityEngine;
using System;

public class CubeSpawner : MonoBehaviour
{
    [Header("ParticleParameters")] 

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    [Header("SpawningParameters")]
    [SerializeField] private CubesController _controller;
    [SerializeField] private int _minCubesSpawned;
    [SerializeField] private int _maxCubesSpawned;
    [SerializeField] private int _neededPercentsChance;
    [SerializeField] private int _maxRandomPercentsChance;
    [SerializeField] private int _minRandomPercents;
    [SerializeField] private int _smallerVariablesCubeCoefficient;

    private Cube _newCubeScript;

    public event Action<Cube> CubeSpawned;

    private void OnEnable()
    {
        _controller.CubeFound += SpawnCubes;
    }

    private void OnDisable()
    {
        _controller.CubeFound -= SpawnCubes;
    }

    private void SpawnCubes(Cube newCube)
    {
        int _ourPercentsChance = UnityEngine.Random.Range(_minRandomPercents, _maxRandomPercentsChance+1);

        int cubesCount = UnityEngine.Random.Range(_minCubesSpawned, _maxCubesSpawned+1);

        if(_ourPercentsChance < newCube.neededPercentsChance)
        {
            for(int i = 0; i < cubesCount; i++)
            {
                GameObject createdCube = Instantiate(newCube.gameObject, newCube.gameObject.transform.position, newCube.gameObject.transform.rotation);

                _newCubeScript = createdCube.GetComponent<Cube>();
        
                _newCubeScript.DecreaseSpawnChances(_smallerVariablesCubeCoefficient);
                createdCube.transform.localScale = new Vector3(newCube.transform.localScale.x / _smallerVariablesCubeCoefficient, newCube.transform.localScale.y / _smallerVariablesCubeCoefficient, newCube.transform.localScale.z / _smallerVariablesCubeCoefficient); 
            }

            CubeSpawned?.Invoke(newCube);
        }

        Destroy(newCube.gameObject);
    }
}
