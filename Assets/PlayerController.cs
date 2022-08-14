using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] collectables;
    Rigidbody2D rb;
    bool isGrounded;
    Animator anim;
    SpriteRenderer spriteRenderer;

    public LayerMask whatIsGround;
    public float movementSpeed = 5;
    public Transform groudCheckPosition;
    public float jumpForce = 10;
    int jumpCount = 0;

    //Coyote Time
    public float hangTime = 0.3f;
    float hangCounter;

    //Jump Before Player Hits Ground
    public float jumpBufferLenght = 0.2f;
    private float jumpBufferCount;

    //Fall faster afterjump
    public float fallMultiplier = 2.5f, lowJumpMultiplier = 2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ResetCollectables();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groudCheckPosition.position, .1f, whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        //Handle Coyote Time
        if (isGrounded)
        {
            hangCounter = hangTime;
            jumpCount = 0;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        //Handle Jump Buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;
            jumpCount++;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        //Jump
        if (jumpBufferCount >= 0 && hangCounter > 0 && jumpCount < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }

        if (!Input.GetButton("Jump") && rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = true;
        }// Moving Right
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = false;
        }// Moving Left
        else
        {
            
        }// Idle
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            ResetCollectables();
        }
    }

    void ResetCollectables()
    {
        for(int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }

        collectables[Random.Range(0, collectables.Length)].SetActive(true);
    }
}
