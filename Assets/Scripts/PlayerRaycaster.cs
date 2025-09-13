using UnityEngine;
using System;

public class PlayerRaycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    
    public event Action<Cube> CubeFound;
    
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
                CubeFound?.Invoke(hit.collider.gameObject.GetComponent<Cube>());
            }
        }
    }
}
