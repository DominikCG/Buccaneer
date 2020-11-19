using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player_rg = default;
    [SerializeField] private float movement_speed = default;
    [SerializeField] private float rotation_speed = default;
    [SerializeField] private float axis_y = default;
    [SerializeField] private float axis_x = default;



    // Update is called once per frame
    void Update()
    {
        axis_y = Input.GetAxis("Vertical");
        axis_x = Input.GetAxis("Horizontal");
        

        Move_Ship_Forward(axis_y * movement_speed);
        Rotate_Ship(transform, axis_x * -rotation_speed);
      
    }

    private void Move_Ship_Forward(float acceleration)
    {
        if(acceleration > 0){

        Vector2 move = transform.up * acceleration *Time.deltaTime;
        player_rg.AddForce(move);
        }
    }
    private void Rotate_Ship(Transform t, float rotationSpeed)
    {
        t.Rotate(0, 0, rotationSpeed *Time.deltaTime);
    }

}

