using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public float rotationSpeed = 10.0f;
    public float JumpForce = 300f;
    private float horizontalInput;
    private float verticalInput;

    private bool isGrounded;

    private Rigidbody playerRb;
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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * Speed  * Time.deltaTime);

        /*if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }*/
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
}
