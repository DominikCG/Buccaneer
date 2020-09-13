using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    [SerializeField] private GameObject cannon_ball_prefab = default;

    [SerializeField] private Transform[] player_right_cannons = default;
    [SerializeField] private Transform[] player_left_cannons = default;
    [SerializeField] private Transform player_front_cannon = default;

    [SerializeField] private Camera cam = default;

    [SerializeField] private float ball_speed = 20f;
    [SerializeField] private Rigidbody2D player_rb = default;
    [SerializeField] private Vector2 mouse_position;
    [SerializeField] Vector2 shoot_direction;
    [SerializeField] private float angle = 0f;
    [SerializeField] private float angle_mouse = 0f;


    [SerializeField] private int damage = 10;
    // Update is called once per frame
    void Update()
    {
        mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
        shoot_direction = mouse_position - player_rb.position;
        angle = player_rb.rotation;
        angle_mouse = (Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90)- angle;
        
        if (angle_mouse < -180)
        {
            angle_mouse = +360 + angle_mouse;
        }
        if (angle_mouse > 180)
        {
            angle_mouse = -360 + angle_mouse;
        }

        if (Input.GetButtonDown("Fire1") && angle_mouse < 65 && angle_mouse > -65)
        {
            shoot();
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse < -65 && angle_mouse > -145)
        {
            shoot_right();
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse > 65 && angle_mouse < 145)
        {
            shoot_left();
        }
    }

    private void shoot_left()
    {
        for (int i = 0; i < player_left_cannons.Length; i++)
        {

            GameObject ball = Instantiate(cannon_ball_prefab, player_left_cannons[i].position, player_left_cannons[i].rotation);
            ball.GetComponent<Cannon_ball>().SetBallDamage(damage);
            Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
            ball_rg.AddForce(-player_left_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    void shoot_right()
    {
        for (int i = 0; i < player_right_cannons.Length; i++)
        {

        GameObject ball = Instantiate(cannon_ball_prefab, player_right_cannons[i].position, player_right_cannons[i].rotation);
        ball.GetComponent<Cannon_ball>().SetBallDamage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(player_right_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    void shoot(){
        GameObject ball = Instantiate(cannon_ball_prefab, player_front_cannon.position, player_front_cannon.rotation);
        ball.GetComponent<Cannon_ball>().SetBallDamage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(player_front_cannon.up * ball_speed, ForceMode2D.Impulse);
    }


}
