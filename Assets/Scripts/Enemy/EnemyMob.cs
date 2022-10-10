using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMob : MonoBehaviour
{
    private float angle_mouse = default;
    private float angle = default;
    private bool slashReady = true;
    private bool chase = false;
    private bool backToPos = false;
    private Vector2 direction = default;
    private GameObject target = default;
    private Vector2 shoot_direction = default;
    private Collider2D playerCollider;
    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private float movementSpeed = default;
    [SerializeField] private Vector2 axis = default;
    [SerializeField] private Collider2D range;
    [SerializeField] float delaySlash = default;
    [SerializeField] private float distance = default;
    [SerializeField] private Vector2 playerPos = default;
    [SerializeField] private Vector2 lastPos = default;
    [SerializeField] private Camera cam = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;
    [SerializeField] private Animator anim;
    [SerializeField]private Health_bar hp;
     [SerializeField]private int dmg;
     int myHealth;
     bool stop = false;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player");
        hp.SetMaxHealth(100);   
        myHealth = 100;

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
        if(distance > 5){
            chase=false;
            StartCoroutine(BackToPosCoroutine());
        }

        if(range.IsTouching(target.GetComponent<Collider2D>())){
            chase=true;
            backToPos = false;
        }

  
    }   

    void FixedUpdate(){
        if(!stop){

            if(chase){
                Move(movementSpeed);
            }else if(backToPos){
                Move(0.5f,lastPos-(Vector2)transform.position);
            }
        }

    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log(collision.gameObject.name);
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("hit");
    //         //collision.gameObject.SendMessage("ApplyDamage", 10);
    //     }
    // }

    private void Move(float ACC, Vector2 DIR)
    {
        if(distance > 2 && distance < 20)
            rb.MovePosition(rb.position + DIR * ACC * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position,target.GetComponent<Rigidbody2D>().position,ACC*Time.deltaTime);
    }
    private void Move(float ACC)
    {

        if(distance > 2 && distance < 20){
            Vector3 temp = Vector3.MoveTowards(transform.position,target.GetComponent<Rigidbody2D>().position,ACC*Time.deltaTime);
            rb.MovePosition(temp);
        }
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
                //Debug.Log("frente");

            } else if (angle_mouse < -45 && angle_mouse > -145){
                anim.SetTrigger("right");
                //Debug.Log("direita");

            } else if (angle_mouse > 45 && angle_mouse < 145){
                anim.SetTrigger("left");
                //Debug.Log("esquerda");
            }else{
                anim.SetTrigger("down");
                //Debug.Log("costa");
            }
        slashReady = false;
    }

    void AngleCalc(){
        //playerPos = cam.ScreenToWorldPoint(Input.mousePosition);
        shoot_direction = target.transform.position - transform.position;
        angle = rb.rotation;
        angle_mouse = (Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90)- angle;
    }
    public void Take_Damage(int DAMAGE)
    {
        hp.SetHealth(DAMAGE);
        myHealth -=DAMAGE;
        if(myHealth <= 0){
            Dead();
        }
        stop = true;
        StartCoroutine(KnockCoroutine());
    }
    IEnumerator SlashCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delaySlash);
        slashReady = true;
    }

    IEnumerator KnockCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        stop = false;
    }

    IEnumerator BackToPosCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        if(!chase){
            backToPos = true;
        }
    }

    private void Dead(){
        gameObject.SetActive(false);
    }
}
