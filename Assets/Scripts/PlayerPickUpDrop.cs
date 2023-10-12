using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.PickUpItems.started += PickUpItems_started;
        playerInputActions.Player.PickUpItems.canceled += PickUpItems_canceled; 
    }

    private void PickUpItems_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Canceled");
    }

    private void PickUpItems_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Started");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
    }
}
