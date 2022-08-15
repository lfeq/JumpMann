using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteTime : MonoBehaviour
{
    public float coyoteTime = 0.3f;
    private static float coyoteTimeCounter;

    // Update is called once per frame
    void Update()
    {
        coyoteTimeCounter -= Time.deltaTime;
        if (Collisions.isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
    }

    public static bool JumpingInCoyoteTime()
    {
        if (coyoteTimeCounter > 0)
        {
            coyoteTimeCounter = -10;
            return true;
        }

        return false;
    }
}
