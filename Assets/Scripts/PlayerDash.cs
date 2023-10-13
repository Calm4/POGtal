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
    public float dashCooldown;
    private float dashCooldownTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();

    }

    private void Dash()
    {
        if (dashCooldownTimer > 0)
        {
            return;
        }
        else
        {
            dashCooldownTimer -= Time.deltaTime;
        }
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        delayedForceToApply = forceToApply;
        playerRigidbody.AddForce(forceToApply, ForceMode.Impulse);
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);

    }
    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {

    }

    private void ResetDash()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            Dash();
        }
    }
}
