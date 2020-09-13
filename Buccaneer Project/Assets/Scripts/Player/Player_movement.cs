using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player_rg = null;
    [SerializeField] private float movement_speed = 0f;
    [SerializeField] private float rotation_speed = 0f;
    [SerializeField] private float axis_y;
    [SerializeField] private float axis_x;



    // Update is called once per frame
    void Update()
    {
        axis_y = Input.GetAxis("Vertical");
        float axis_x = Input.GetAxis("Horizontal");
        

        MoveShipForward(axis_y * movement_speed);
        RotateShip(transform, axis_x * -rotation_speed);
      
    }

    private void MoveShipForward(float acceleration)
    {
        if(acceleration > 0){

        Vector2 move = transform.up * acceleration *Time.fixedDeltaTime;
        player_rg.AddForce(move);
        }
    }
    private void RotateShip(Transform t, float rotationSpeed)
    {
        t.Rotate(0, 0, rotationSpeed);
    }

}

