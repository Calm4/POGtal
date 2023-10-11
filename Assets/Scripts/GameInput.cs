using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    // Start is called before the first frame update
    private Rigidbody playerRigidbody;
    private void Awake()
    {
       playerRigidbody = GetComponent<Rigidbody>();
       playerInputActions = new PlayerInputActions();
       playerInputActions.Player.Enable();
    }

    private void Start()
    {
       
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return  inputVector;
    }
    private void Jump()
    {
         
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }


}
