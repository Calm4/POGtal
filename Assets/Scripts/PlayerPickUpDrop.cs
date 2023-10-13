using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    [SerializeField] private Transform cameraTransform;

    private void Awake()
    {

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.PickUpItems.started += PickUpItems_started;
        playerInputActions.Player.PickUpItems.canceled += PickUpItems_canceled; 
    }

    private void PickUpItems_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       // Debug.Log("Canceled");
    }

    private void PickUpItems_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        float pickUpDistance = 20f;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
        {
            Debug.Log("Опана");
            if(raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                Debug.Log(objectGrabbable);
            }
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
    }
}
