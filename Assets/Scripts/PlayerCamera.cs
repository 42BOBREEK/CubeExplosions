using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensX;    
    [SerializeField] private float sensY;    

    [SerializeField] private float _minViewBorderX;    
    [SerializeField] private float _maxViewBorderX;    

    [SerializeField] private Transform _orientation;

    private float xRotation;
    private float yRotation;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, _minViewBorderX, _maxViewBorderX);

        transform.rotation = Quaternion.Euler(xRotation, yRotation,  0);
        _orientation.rotation = Quaternion.Euler(0, yRotation,  0);
    }
}
