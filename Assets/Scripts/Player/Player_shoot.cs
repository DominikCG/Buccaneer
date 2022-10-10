﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_shoot : MonoBehaviour
{
    [SerializeField] private Camera cam = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;
    [SerializeField] private Rigidbody2D player_rb = default;
    [SerializeField] private Transform[] player_right_cannons = default;
    [SerializeField] private Transform[] player_left_cannons = default;
    [SerializeField] private Transform player_front_cannon = default;
    [SerializeField] private float time_to_shoot = default;
    [SerializeField] private float ball_speed = default;
    [SerializeField] private int damage = default;
    [SerializeField] private bool player_ball = default;
    private Vector2 mouse_position = default;
    private Vector2 shoot_direction = default;
    private float angle = default;
    private float angle_mouse = default;
    private float timer_cannon_f = default;
    private float timer_cannon_l = default;
    private float timer_cannon_r = default;
    public Image imageCooldown_f;
    public float cooldown_f;
    bool isCooldown_f;
    public Image imageCooldown_l;
    public float cooldown_l;
    bool isCooldown_l;
    public Image imageCooldown_r;
    public float cooldown_r;
    bool isCooldown_r;

    private void Start()
    {
        timer_cannon_f = time_to_shoot;
        timer_cannon_l = time_to_shoot;
        timer_cannon_r = time_to_shoot;
        cooldown_f = time_to_shoot;
        cooldown_l = time_to_shoot;
        cooldown_r = time_to_shoot;
        player_ball = true;
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
            if(timer_cannon_f > time_to_shoot)
            {
                Shoot_Front();
                timer_cannon_f = 0f;
                isCooldown_f = true;
            }
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse < -45 && angle_mouse > -145)
        {
            if (timer_cannon_r > time_to_shoot)
            {
                Shoot_Right();
                timer_cannon_r = 0f;
                isCooldown_r = true;
            }
        }
        if (Input.GetButtonDown("Fire1") && angle_mouse > 45 && angle_mouse < 145)
        {
            if (timer_cannon_l > time_to_shoot) {
                Shoot_Left();
                timer_cannon_l = 0f;
                isCooldown_l = true;
            }
        }
        if(isCooldown_f)
        {
            imageCooldown_f.fillAmount += 1 / cooldown_f * Time.deltaTime;
            if(imageCooldown_f.fillAmount >=1)
            {
                imageCooldown_f.fillAmount = 0;
                isCooldown_f = false;
            }
        }
        if (isCooldown_l)
        {
            imageCooldown_l.fillAmount += 1 / cooldown_l * Time.deltaTime;
            if (imageCooldown_l.fillAmount >= 1)
            {
                imageCooldown_l.fillAmount = 0;
                isCooldown_l = false;
            }
        }
        if (isCooldown_r)
        {
            imageCooldown_r.fillAmount += 1 / cooldown_l * Time.deltaTime;
            if (imageCooldown_r.fillAmount >= 1)
            {
                imageCooldown_r.fillAmount = 0;
                isCooldown_r = false;
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
            ball.GetComponent<Cannon_ball>().Shoot_From_Player(player_ball);
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
            ball.GetComponent<Cannon_ball>().Shoot_From_Player(player_ball);
            ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
            Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
            ball_rg.AddForce(player_right_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    private void Shoot_Front(){
        GameObject ball = Instantiate(cannon_ball_prefab, player_front_cannon.position, player_front_cannon.rotation);
        ball.GetComponent<Cannon_ball>().Shoot_From_Player(player_ball);
        ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(player_front_cannon.up * ball_speed, ForceMode2D.Impulse);
    }


}
