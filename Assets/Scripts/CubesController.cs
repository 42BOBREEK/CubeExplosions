using UnityEngine;
using System;

public class CubesController : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private PlayerRaycaster _raycaster;

    private Cube _foundCube;

    public event Action<Cube> CubeSpawned;
    public event Action<Cube> CubeFound;

    private void OnEnable()
    {
        _raycaster.CubeFound += InvokeSpawning;
        _spawner.CubeSpawned += InvokeExploding;
    }

    private void OnDisable()
    {
        _raycaster.CubeFound -= InvokeSpawning;
        _spawner.CubeSpawned -= InvokeExploding;
    }

    private void InvokeSpawning(Cube foundCube)
    {
        CubeFound?.Invoke(foundCube);
    }

    private void InvokeExploding(Cube foundCube)
    {
        CubeSpawned?.Invoke(foundCube);
    }
}

