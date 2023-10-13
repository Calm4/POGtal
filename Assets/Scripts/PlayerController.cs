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
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        MovePlayerCamera();
    }

    private void PlayerMovement()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        playerRb.velocity = new Vector3(MoveVector.x, playerRb.velocity.y, MoveVector.z);

    }
    private void PlayerJump()
    {
        if (Physics.CheckSphere(feetTransform.position, 0.3f, floorMask)) // ≈сли игрок стоит на разрешенной поверхности, то:
        {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            isGrounded = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal") / 2, 0f, Input.GetAxis("Vertical"));
                isGrounded = false;

            }
            else if (Input.GetKey(KeyCode.S))
            {
                PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal") / 2, 0f, Input.GetAxis("Vertical") / 3);
                isGrounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }
    private void MovePlayerCamera()
    {
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xRotation = Mathf.Clamp(xRotation - PlayerMouseInput.y * Sensitivity, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
