using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _sensX;    
    [SerializeField] private float _sensY;    

    [SerializeField] private float _zRotation;

    [SerializeField] private float _minViewBorderX;    
    [SerializeField] private float _maxViewBorderX;    

    [SerializeField] private Transform _orientation;

    private float _xRotation;
    private float _yRotation;

    private void Update()
    {
        float mouseX = _inputReader.mouseAxisX * Time.deltaTime * _sensX;
        float mouseY =  _inputReader.mouseAxisY * Time.deltaTime * _sensY;

        _yRotation += mouseX;
        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, _minViewBorderX, _maxViewBorderX);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation,  _zRotation);
        _orientation.rotation = Quaternion.Euler(_xRotation, _yRotation,  _zRotation);
    }
}
