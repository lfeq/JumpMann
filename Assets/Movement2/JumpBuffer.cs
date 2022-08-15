using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuffer : MonoBehaviour
{
    public float jumpBufferTime = 0.2f;
    private static float jumpBufferCounter;

    // Update is called once per frame
    void Update()
    {
        jumpBufferCounter -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
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
