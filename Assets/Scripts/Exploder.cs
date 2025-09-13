using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private CubesController _controller;

    private void OnEnable()
    {
        _controller.CubeSpawned += Explode;
    }

    private void OnDisable()
    {
        _controller.CubeSpawned += Explode;
    }

    private void Explode(Cube cube)
    {
        Instantiate(_effect, cube.gameObject.transform.position, cube.gameObject.transform.rotation);

        foreach(Rigidbody explodableObject in GetExplodableObjects(cube.gameObject))
            explodableObject.AddExplosionForce(_explosionForce, cube.gameObject.transform.position, _explosionRadius);
    }
  
    private List<Rigidbody> GetExplodableObjects(GameObject explodableObject)
    {
        Collider[] hits = Physics.OverlapSphere(explodableObject.transform.position, _explosionRadius);

        List<Rigidbody> objects = new();
 
        foreach(Collider hit in hits)
            if(hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);
        return objects;
    }
}
