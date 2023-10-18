using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public void Grab(Transform objectGrabPointTransform)
    {
        /* objectGrabPointTransform.position = this.transform.position;
         this.objectGrabPointTransform = objectGrabPointTransform;*/

        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Move()
    {
        Debug.Log("MOVE");
        float forceSpeed = 15f;
        var vectorToThrow = objectGrabPointTransform.forward;
        Drop();
        objectRigidbody.AddForce(vectorToThrow * forceSpeed, ForceMode.Impulse); //.velocity = vectorToThrow * forceSpeed * Time.deltaTime;
        
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
