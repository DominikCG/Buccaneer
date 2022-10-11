using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;
    [SerializeField] private Rigidbody2D enemy_rg = default;
    [SerializeField] private Transform[] enemy_right_cannons = default;
    [SerializeField] private Transform[] enemy_left_cannons = default;
    [SerializeField] private Transform enemy_front_cannon = default;
    [SerializeField] private Vector2 player_position = default; // To Delete
    [SerializeField] private Vector2 direction = default; // To Delete
    [SerializeField] private float distance = default;
    [SerializeField] private float maximum_distance = default;
    [SerializeField] private float distance_to_shoot = default;
    [SerializeField] private float speed = default; // To Delete
    [SerializeField] private float turn = default; // To Delete 
    [SerializeField] private float ball_speed = default;
    [SerializeField] private float angle = default; // To Delete
    [SerializeField] private int damage = default;
    [SerializeField] private bool enemy_ball = default;
    [SerializeField] private float angle_to_shoot = default; // To Delete
    private float timer_cannon_f = default;
    private float timer_cannon_l = default;
    private float timer_cannon_r = default;
    private NavMeshAgent agent;
    private bool wait_aim;


    private void Start()
    {
        enemy_ball = true;
        wait_aim = true;

        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {           
            Timer_Control();
            AI_Controler();
        }
    }

    private void Timer_Control()
    {
        timer_cannon_f += Time.deltaTime;
        timer_cannon_l += Time.deltaTime;
        timer_cannon_r += Time.deltaTime;
    }

    private void AI_Controler()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        // Check if should chase player
        if (distance > maximum_distance) 
        {
            // Path to target
            agent.SetDestination(player.transform.position);

            // Rotate enemy sprite according to path
            Vector3 direction_to_target = (agent.steeringTarget - transform.position).normalized;
            float angle_to_target = (Mathf.Atan2(direction_to_target.y, direction_to_target.x) * Mathf.Rad2Deg) - 90;  
            enemy_rg.MoveRotation(Mathf.LerpAngle(enemy_rg.rotation,angle_to_target, 100 * Time.deltaTime));
        
            wait_aim = true;
        }
        //  Or stop, aim and shoot
        else 
        {
            // Rotate enemy sprite according to player
            Vector3 direction_to_target = (player.transform.position - transform.position).normalized;
            float angle_to_target = (Mathf.Atan2(direction_to_target.y, direction_to_target.x) * Mathf.Rad2Deg);  
            enemy_rg.MoveRotation(Mathf.LerpAngle(enemy_rg.rotation,angle_to_target, 100 * Time.deltaTime));

            if (wait_aim) 
            {
                wait_aim = false;
                if (timer_cannon_l > 4)
                    timer_cannon_l = 3.5f;
                if(timer_cannon_r > 4)
                    timer_cannon_r = 3.5f;
            }
        }

        // Check enemy position relative to player to choose which cannon to shoot   
        var relativePoint = transform.InverseTransformPoint(player.transform.position);
        if ((relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y)) // Left
            && timer_cannon_l > 4 
            && gameObject.CompareTag("Enemy_shooter") 
            && distance < distance_to_shoot)
        {
            Shoot_Left();
            timer_cannon_l = 0f;
        }
        if ((relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y)) // Right
            && timer_cannon_r > 4 
            && gameObject.CompareTag("Enemy_shooter") 
            && distance < distance_to_shoot)
        {
            Shoot_Right();
            timer_cannon_r = 0f;
        }
        if ((relativePoint.y > 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y)) // Front
            && timer_cannon_f > 4
            && gameObject.CompareTag("Enemy_shooter") 
            && distance < distance_to_shoot) 
        {
            Shoot_Front();
            timer_cannon_f = 0f;
        }
        if ((relativePoint.y < 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))) // Behind
        {
            // Do nothing
        }

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
