using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Start()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        _meshRenderer.material.color = Random.ColorHSV();
    }
}
