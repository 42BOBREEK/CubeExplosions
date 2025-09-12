using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private CubeSpawner _cubeSpawner;

    void OnEnable()
    {
        _cubeSpawner.CubeSpawned += Explode;
    }

    void OnDisable()
    {
        _cubeSpawner.CubeSpawned += Explode;
    }

    private void Explode(GameObject cube)
    {
        Instantiate(_effect, cube.transform.position, cube.transform.rotation);

        foreach(Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
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
