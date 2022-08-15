using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    public static void ResetPosition(GameObject gameObject)
    {
        gameObject.transform.position = spawnPosition;
    }
}
