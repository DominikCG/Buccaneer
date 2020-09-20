using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;
    [SerializeField] private Rigidbody2D enemy_rg = default;
    [SerializeField] private Transform[] enemy_right_cannons = default;
    [SerializeField] private Transform[] enemy_left_cannons = default;
    [SerializeField] private Transform enemy_front_cannon = default;
    [SerializeField] private Vector2 player_position = default;
    [SerializeField] private Vector2 direction = default;
    [SerializeField] private float distance = default;
    [SerializeField] private float maximum_distance = default;
    [SerializeField] private float distance_to_shoot = default;
    [SerializeField] private float speed = default;
    [SerializeField] private float turn = default;   
    [SerializeField] private float ball_speed = default;
    [SerializeField] private float angle = default;
    [SerializeField] private int damage = default;
    [SerializeField] private bool enemy_ball = default;
    [SerializeField] private float angle_to_shoot = default;
    private float timer_cannon_f = default;
    private float timer_cannon_l = default;
    private float timer_cannon_r = default;

    private void Start()
    {
        enemy_ball = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);

            Timer_Control();
            AI_Controler();
        }
    }

    private void AI_Controler()
    {
        player_position = player.GetComponent<Transform>().position;
        direction = player_position - (Vector2)transform.position;
        direction.Normalize();
        angle = enemy_rg.rotation;

        float follow = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90); // tirar isso

      

        angle_to_shoot = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90) - angle;

        if (angle_to_shoot < -180)
            angle_to_shoot = +360 + angle_to_shoot;

        if (angle_to_shoot > 180)
            angle_to_shoot = -360 + angle_to_shoot;

        float turning = (Mathf.Lerp(transform.position.z, angle_to_shoot, Time.deltaTime*turn));
        transform.Rotate(0, 0, turning);
       


        if (gameObject.CompareTag("Enemy_shooter") && distance > maximum_distance)
        {  
            Vector2 move = transform.up * speed * Time.fixedDeltaTime;
            enemy_rg.AddForce(move);
        }
        if(gameObject.CompareTag("Enemy_chaser"))
        {
            Vector2 move = transform.up * speed * Time.fixedDeltaTime;
            enemy_rg.AddForce(move);
        }



        if (timer_cannon_f > 4 && angle_to_shoot < 25 && angle_to_shoot > -25 && gameObject.CompareTag("Enemy_shooter") && distance < distance_to_shoot)
        {
            Shoot_Front();
            timer_cannon_f = 0f;
        }

        if (timer_cannon_r > 4 && angle_to_shoot < -80 && angle_to_shoot > -120 && gameObject.CompareTag("Enemy_shooter") && distance < distance_to_shoot)
        {
            Shoot_Right();
            timer_cannon_r = 0f;
        }

        if (timer_cannon_l > 4 && angle_to_shoot < 120 && angle_to_shoot > 80 && gameObject.CompareTag("Enemy_shooter") && distance < distance_to_shoot)
        {
            Shoot_Left();
            timer_cannon_l = 0f;
        }

    
}

    private void Timer_Control()
    {
        timer_cannon_f += Time.deltaTime;
        timer_cannon_l += Time.deltaTime;
        timer_cannon_r += Time.deltaTime;
    }


    private void Shoot_Left()
    {
        for (int i = 0; i < enemy_left_cannons.Length; i++)
        {

            GameObject ball = Instantiate(cannon_ball_prefab, enemy_left_cannons[i].position, enemy_left_cannons[i].rotation);
            ball.GetComponent<Cannon_ball>().Shoot_From_Enemy(enemy_ball);
            ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
            Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
            ball_rg.AddForce(-enemy_left_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    private void Shoot_Right()
    {
        for (int i = 0; i < enemy_right_cannons.Length; i++)
        {

            GameObject ball = Instantiate(cannon_ball_prefab, enemy_right_cannons[i].position, enemy_right_cannons[i].rotation);
            ball.GetComponent<Cannon_ball>().Shoot_From_Enemy(enemy_ball);
            ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
            Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
            ball_rg.AddForce(enemy_right_cannons[i].right * ball_speed, ForceMode2D.Impulse);
        }
    }

    private void Shoot_Front()
    {
        GameObject ball = Instantiate(cannon_ball_prefab, enemy_front_cannon.position, enemy_front_cannon.rotation);
        ball.GetComponent<Cannon_ball>().Shoot_From_Enemy(enemy_ball);
        ball.GetComponent<Cannon_ball>().Set_Ball_Damage(damage);
        Rigidbody2D ball_rg = ball.GetComponent<Rigidbody2D>();
        ball_rg.AddForce(enemy_front_cannon.up * ball_speed, ForceMode2D.Impulse);
    }


}
