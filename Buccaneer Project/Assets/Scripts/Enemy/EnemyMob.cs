using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private float movementSpeed = default;
    [SerializeField] private Vector2 axis = default;
    private float angle_mouse = default;
    private float angle = default;
    private bool slashReady = true;
    [SerializeField] float delaySlash = default;
    [SerializeField] private float distance = default;
    private Vector2 shoot_direction = default;
    [SerializeField] private Vector2 playerPos = default;
    private Vector2 direction = default;
    private GameObject target = default;
    [SerializeField] private Camera cam = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;

    [SerializeField] private Animator anim;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        playerPos = target.GetComponent<Transform>().position;
        direction = playerPos - (Vector2)transform.position;
        distance = Vector3.Distance(target.transform.position, transform.position);

        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);

        if(distance <= 2 && slashReady){
            Slash();
            StartCoroutine(SlashCoroutine());
        }

    }   

    void FixedUpdate(){

        Move(movementSpeed,direction);

    }
    private void Move(float ACC, Vector2 DIR)
    {
        if(distance > 2 && distance < 20)
            rb.MovePosition(rb.position + DIR * ACC * Time.deltaTime);
    }

    private void Shoot(){
        AngleCalc();
        if (angle_mouse < -180)
            angle_mouse = 360 + angle_mouse;
        
        if (angle_mouse > 180)
            angle_mouse = -360 + angle_mouse;
        

        if (angle_mouse < 45 && angle_mouse > -45){
            Debug.Log("frente");

        } else if (angle_mouse < -45 && angle_mouse > -145){
            Debug.Log("direita");

        } else if (angle_mouse > 45 && angle_mouse < 145){
            Debug.Log("esquerda");
        }else{
            Debug.Log("costa");
        }
    }

    private void Slash(){
        AngleCalc();
        if (angle_mouse < -180)
            angle_mouse = 360 + angle_mouse;
        
        if (angle_mouse > 180)
            angle_mouse = -360 + angle_mouse;

            if (angle_mouse < 45 && angle_mouse > -45){

                anim.SetTrigger("up");
                Debug.Log("frente");

            } else if (angle_mouse < -45 && angle_mouse > -145){
                anim.SetTrigger("right");
                Debug.Log("direita");

            } else if (angle_mouse > 45 && angle_mouse < 145){
                anim.SetTrigger("left");
                Debug.Log("esquerda");
            }else{
                anim.SetTrigger("down");
                Debug.Log("costa");
            }
        slashReady = false;
    }

    void AngleCalc(){
        //playerPos = cam.ScreenToWorldPoint(Input.mousePosition);
        shoot_direction = target.transform.position - transform.position;
        angle = rb.rotation;
        angle_mouse = (Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90)- angle;
    }

    IEnumerator SlashCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delaySlash);
        slashReady = true;
    }
}
