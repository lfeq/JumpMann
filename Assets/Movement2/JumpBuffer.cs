using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBuffer : MonoBehaviour
{
    private static float jumpBufferCounter;
    InputAction jump;

    public float jumpBufferTime = 0.2f;


    private void Start()
    {
        jump = InputManager.playerInput.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        jumpBufferCounter -= Time.deltaTime;
        if (jump.triggered)
        {
            jumpBufferCounter = jumpBufferTime;
        }
    }

    public static bool JumpedBeforeTouchingGround()
    {
        if(jumpBufferCounter >= 0)
        {
            jumpBufferCounter = -10;
            return true;
        }

        return false;
    }
}
