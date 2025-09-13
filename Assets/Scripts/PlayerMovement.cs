using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = _orientation.forward * _inputReader.VerticalInput + _orientation.right * _inputReader.HorizontalInput;

        rb.AddForce(moveDirection.normalized * _moveSpeed, ForceMode.Force);
    }
}
