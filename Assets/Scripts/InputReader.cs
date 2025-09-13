using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string MouseXAxis = "Mouse X";
    private const string MouseYAxis = "Mouse Y";

    [SerializeField] private int _mouseButtonNumber;

    public float MouseAxisX { get; private set; }
    public float MouseAxisY { get; private set; }

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    public event Action MouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
        {
            MouseClicked?.Invoke();
        }

        HorizontalInput = Input.GetAxisRaw(HorizontalAxis);
        VerticalInput = Input.GetAxisRaw(VerticalAxis);
        
        MouseAxisX = Input.GetAxisRaw(MouseXAxis); 
        MouseAxisY = Input.GetAxisRaw(MouseYAxis); 
    }
}
