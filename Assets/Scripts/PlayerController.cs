using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;

    private float xRotation;

    [SerializeField] private LayerMask floorMask;
    [SerializeField] private Transform feetTransform;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Transform playerCamera;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;
    [Space]


    private Vector3 Velocity;




    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerRb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        playerRb.velocity = new Vector3(MoveVector.x, playerRb.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("1");
            if (Physics.CheckSphere(feetTransform.position, 0.3f, floorMask))
            {
            Debug.Log("2");
                playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }

        /*

                if (directionVector.magnitude > Mathf.Abs(0.1f))
                {
                    // Поворот игрока
                    float targetAngle = Mathf.Atan2(directionVector.x, directionVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // для отслеживания поворота камеры приплюсуем eulerAngles.y
                    // Плавность для поворота
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // forward - перед для камеры и для игрока
                    playerRb.velocity = moveDir.normalized * Speed;
                }*/

    }
    private void MovePlayerCamera()
    {
        xRotation = Mathf.Clamp(xRotation - PlayerMouseInput.y * Sensitivity, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }




    /* private void CameraRotating()
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
               transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
         }

     }*/
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


}
