using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    [SerializeField] private Camera cam = default;

    [SerializeField] private GameObject cannon_ball_prefab = default;
    [SerializeField] private Rigidbody2D player_rb = default;

    [SerializeField] private Transform[] player_right_cannons = default;
    [SerializeField] private Transform[] player_left_cannons = default;
    [SerializeField] private Transform player_front_cannon = default;


    [SerializeField] private float ball_speed = default;

    [SerializeField] private int damage = default;


    private Vector2 mouse_position;
    private Vector2 shoot_direction;
    private float angle = 0f;
    private float angle_mouse = 0f;
    private float timer_cannon_f = 0f;
    private float timer_cannon_l = 0f;
    private float timer_cannon_r = 0f;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Timer_Control();
        mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
        shoot_direction = mouse_position - player_rb.position;
        angle = player_rb.rotation;
        angle_mouse = (Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90)- angle;
        
        if (angle_mouse < -180)
            angle_mouse = +360 + angle_mouse;
        
        if (angle_mouse > 180)
            angle_mouse = -360 + angle_mouse;
        

        if (Input.GetButtonDown("Fire1") && angle_mouse < 45 && angle_mouse > -45)
        {
            if(timer_cannon_f > 2)
            {
                Shoot_Front();
                timer_cannon_f = 0f;
            }
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse < -45 && angle_mouse > -145)
        {
            if (timer_cannon_r > 2)
            {
                Shoot_Right();
                timer_cannon_r = 0f;
            }
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse > 45 && angle_mouse < 145)
        {
            if (timer_cannon_l > 2) {
                Shoot_Left();
                timer_cannon_l = 0f;
            }
        }
    }

    private void Timer_Control()
    {
        timer_cannon_f +=Time.deltaTime;
        timer_cannon_l += Time.deltaTime;
        timer_cannon_r += Time.deltaTime;
    }

    private void Shoot_Left()
    {
        for (int i = 0; i < player_left_cannons.Length; i++)
        {

            GameObject ball = Instantiate(cannon_ball_prefab, player_left_cannons[i].position, player_left_cannons[i].rotation);
            ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
            Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
            ball_rg.AddForce(-player_left_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    private void Shoot_Right()
    {
        for (int i = 0; i < player_right_cannons.Length; i++)
        {

        GameObject ball = Instantiate(cannon_ball_prefab, player_right_cannons[i].position, player_right_cannons[i].rotation);
        ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(player_right_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    private void Shoot_Front(){
        GameObject ball = Instantiate(cannon_ball_prefab, player_front_cannon.position, player_front_cannon.rotation);
        ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(player_front_cannon.up * ball_speed, ForceMode2D.Impulse);
    }


}
