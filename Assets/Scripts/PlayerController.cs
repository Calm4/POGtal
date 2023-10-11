using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public float Speed = 10f;
    public float rotationSpeed = 8000.0f;
    public float JumpForce = 300f;
    private float horizontalInput;
    private float verticalInput;

    private bool isGrounded;

    private Rigidbody playerRb;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 inputVector = GetMovementVectorNormalized();
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Ignore the y-axis rotation of the camera
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * inputVector.y + cameraRight * inputVector.x;

        float speed = 10f;
        transform.position += moveDirection * speed * Time.deltaTime;
 
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }
    private void Jump()
    {
        if (playerInputActions.Player.Jump.triggered && isGrounded)
        {
            playerRb.AddForce(Vector3.up * JumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }
    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Block")
        {
            isGrounded = value;
        }
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
    public Vector2 GetJumpVectorNormolized()
    {
        Vector2 inputVector = playerInputActions.Player.Jump.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
