using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private PlayerInputActions playerInputActions;
    private Rigidbody playerRb;

    public CharacterController controller;
    public Transform cam;
    public float speed = 5f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //playerRb.AddForce(Physics.gravity * 3f, ForceMode.Acceleration);
        Move();
        // Jump();
        //CameraRotating(); 
    }

    private void Move()
    {
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y);

        if (directionVector.magnitude > Mathf.Abs(0.1f))
        {
            // Поворот игрока
            float targetAngle = Mathf.Atan2(directionVector.x, directionVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // для отслеживания поворота камеры приплюсуем eulerAngles.y
            // Плавность для поворота
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // forward - перед для камеры и для игрока
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
            animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        // CameraRotating();

        // playerRb.velocity = Vector3.ClampMagnitude(directionVector, 1) * Speed;





    }

    private void CameraRotating()
    {
        Vector2 inputVector = GetMovementVectorNormalized();
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Ignore the y-axis rotation of the camera
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * inputVector.y + cameraRight * inputVector.x;

        transform.position += moveDirection * speed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }
    /*private void Jump()
    {
        if (playerInputActions.Player.Jump.triggered && isGrounded)
        {
            playerRb.AddForce(Vector3.up * JumpForce * 0.02f, ForceMode.VelocityChange);
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
        if(!value)
        {
            playerRb.AddForce(Physics.gravity * 3f, ForceMode.Acceleration);
        }
    }*/

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
