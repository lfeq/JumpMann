using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;
    Movement movement;
    public float dashingVelocity = 14, dashingTime = 0.5f;
    public TrailRenderer trail;
    private Vector2 dashingDir;
    private bool isDashing, canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canDash)
        {
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
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
