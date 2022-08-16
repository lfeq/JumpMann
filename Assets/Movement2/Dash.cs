using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;
    Movement movement;
    InputAction dashButton;
    Vector2 dashingDir;
    bool isDashing, canDash = true;

    public float dashingVelocity = 14, dashingTime = 0.5f;
    public TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        dashButton = InputManager.playerInput.actions["Dash"];
    }

    // Update is called once per frame
    void Update()
    {
        if ((dashButton.triggered) && canDash)
        {
            dashingDir = new Vector2(movement.GetDirection(), 0);
            isDashing = true;
            canDash = false;
            movement.enabled = false;
            trail.emitting = true;
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        if (Collisions.isGrounded)
        {
            canDash = true;
        }
    }

    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        movement.enabled = true;
        trail.emitting = false;
    }
}
