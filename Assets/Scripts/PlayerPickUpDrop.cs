using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;

    private void Awake()
    {

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.PickUpItems.started += PickUpItems_started;
        playerInputActions.Player.PickUpItems.canceled += PickUpItems_canceled; 
    }

    private void PickUpItems_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(objectGrabbable != null)
        {
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
       // Debug.Log("Canceled");
    }

    private void PickUpItems_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Started");
        float pickUpDistance = 5f;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
        {
            Debug.Log("Опана");
            if(raycastHit.transform.TryGetComponent(out objectGrabbable))
            {
                objectGrabbable.Grab(objectGrabPointTransform);
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
