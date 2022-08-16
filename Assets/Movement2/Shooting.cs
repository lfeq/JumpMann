using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    InputAction shootingButton;
    public GameObject bala;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        shootingButton = InputManager.playerInput.actions["Shoot"];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingButton.triggered)
        {
            GameObject instance = Instantiate(bala, spawnPos.position, Quaternion.identity);
            ConstantForce2D temp_force = instance.GetComponent<ConstantForce2D>();
            temp_force.force = new Vector2(temp_force.force.x * Movement.lastDirection, temp_force.force.y);
            Destroy(instance, 100);
        }//Disparar
    }
}
