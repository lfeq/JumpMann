using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    InputAction jump;

    public float jumpForce = 12;
    public float fallMultiplier = 3, lowJumpMultiplier = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = InputManager.playerInput.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpBuffer.JumpedBeforeTouchingGround() && CoyoteTime.JumpingInCoyoteTime())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && (jump.ReadValue<float>() == 0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


}
