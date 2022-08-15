using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public static bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groudCheckPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groudCheckPosition.position, .1f, whatIsGround);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groudCheckPosition.position, .1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            PlayerHandler.ResetPosition(gameObject);
        }// Respawn
    }
}
