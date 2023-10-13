using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCamera;
    private Rigidbody playerRigidbody;
    private PlayerController playerController;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCooldown = 2f;


    [Header("Input")]
    public KeyCode dashKey = KeyCode.LeftShift;

    private bool canDash = true;
    private Vector3 delayedForceToApply;

    private UIElements uiElements;
    // Start is called before the first frame update
    void Start()
    {

        uiElements = GameObject.Find("UIElements").GetComponent<UIElements>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();

    }

    private void Dash()
    {
       
        uiElements.UpdateUI();
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        playerRigidbody.AddForce(forceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        if (!canDash)
        {
            dashCooldown -= Time.deltaTime; // ��������� ����� ��������

            if (dashCooldown <= 0f)
            {
                
                uiElements.UpdateUI();


                canDash = true; // ����������� ����� �������������
                dashCooldown = 2f; // ����� ������� ��������
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!canDash)
        {
            ResetDash();
        }

        if (Input.GetKeyDown(dashKey) && canDash)
        {
            Dash();
            canDash = false;
        }
        
    }
}
