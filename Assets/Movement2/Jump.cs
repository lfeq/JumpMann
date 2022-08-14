using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    bool inAir;

    //Jump
    public float jumpForce = 5;
    bool jumpRequest;
    float gravityScale;

    //Fall faster
    public float fallMultiplier = 2.5f;

    //Jump Before touching ground
    public float jumpedBeforeTouchingGroundTime = 0.2f;
    float jumpBeforeTouchingGroundTimer;

    //Coyote time
    public float coyoteTime = 0.3f;
    float coyoteTimeCounter;

    [Range(0, 1)]
    public float cutJumpHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float lastFrame = Time.deltaTime;
        jumpBeforeTouchingGroundTimer -= lastFrame;
        coyoteTimeCounter -= lastFrame;

        if (Input.GetButtonDown("Jump"))
        {
            jumpBeforeTouchingGroundTimer = jumpedBeforeTouchingGroundTime;
        }//Checks if player pressed jump button before he touched the ground;

        if (Collisions.isGrounded  && !inAir)
        {
            coyoteTimeCounter = coyoteTime;
        }

        if ((jumpBeforeTouchingGroundTimer > 0) && (coyoteTimeCounter > 0))
        {
            jumpBeforeTouchingGroundTimer = 0;
            coyoteTimeCounter = 0;
            rb.velocity = Vector2.up * jumpForce;
            //jumpRequest = true;
            inAir = true;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpHeight);
        }//Cortar salto, empieza a caer

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * lastFrame;
            inAir = false;
        }//Caer mas rapido
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }
}
