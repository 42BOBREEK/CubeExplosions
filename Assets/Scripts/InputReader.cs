using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private float _mouseAxisX;
    private float _mouseAxisY;

    private float _horizontalInput;
    private float _verticalInput;

    public float MouseAxisX => _mouseAxisX;
    public float MouseAxisY => _mouseAxisY;

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;

    public event Action MouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        _mouseAxisX = Input.GetAxisRaw("Mouse X"); 
        _mouseAxisY = Input.GetAxisRaw("Mouse Y"); 
    }
}
