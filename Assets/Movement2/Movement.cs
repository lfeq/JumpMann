using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float direction;
    InputAction move;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = InputManager.playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>().x;

        rb.velocity = new Vector2(direction * movementSpeed, rb.velocity.y);
    }

    public float GetDirection()
    {
        return direction;
    }
}
