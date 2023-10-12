using UnityEngine;
using Cinemachine;

public class CinemachineCameraRotation : MonoBehaviour
{
    public Transform pivotPoint;
    public CinemachineVirtualCamera virtualCamera;
    public float rotationSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("QEshechki");
        pivotPoint.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        virtualCamera.transform.position = pivotPoint.position;
        virtualCamera.transform.rotation = pivotPoint.rotation;
    }
}
