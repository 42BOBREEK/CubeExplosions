using UnityEngine;
using System;

public class PlayerRaycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    
    private GameObject _foundCube;

    public GameObject foundCube => _foundCube;

    public event Action CubeFound;
    
    private void OnEnable()
    {
        _inputReader.MouseClicked += CubeCheck;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= CubeCheck;
    }

    private bool LookForGameObject(out RaycastHit hit)
    {
       Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

       return Physics.Raycast(ray, out hit);
    }

    private void CubeCheck()
    {
        if(LookForGameObject(out RaycastHit hit))
        {
            if(hit.collider.gameObject.tag == "Cube")
            {
                _foundCube = hit.collider.gameObject;
                CubeFound?.Invoke();
            }
        }
        else 
        {
            _foundCube = null;
        }
    }
}
