using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb = default;
    [SerializeField] private float movementSpeed = default;
    [SerializeField] private Vector2 axis = default;
    private float angle_mouse = default;
    private float angle = default;
    private Vector2 shoot_direction = default;
    private Vector2 mouse_position = default;
    [SerializeField] private Camera cam = default;
    [SerializeField] private GameObject cannon_ball_prefab = default;

    [SerializeField] private Animator playerAnim;

    [SerializeField] private int dmg = 10;
    [SerializeField]private Health_bar hp;
    private int myHealth;
    // Update is called once per frame

    void Start(){
         hp.SetMaxHealth(100);   
         myHealth = 100;
    }
    void Update()
    {
        axis.y = Input.GetAxis("Vertical");
        axis.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire2")){
            Shoot();
        }
        if (Input.GetButtonDown("Fire1")){
            Slash();
        }

    }   

    void FixedUpdate(){

        Move(movementSpeed,axis);

    }
    private void Move(float ACC, Vector2 DIR)
    {
        playerRb.MovePosition(playerRb.position + DIR * ACC * Time.deltaTime);
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
            playerAnim.SetTrigger("up");
            //Debug.Log("frente");

        } else if (angle_mouse < -45 && angle_mouse > -145){
            playerAnim.SetTrigger("right");
            //Debug.Log("direita");

        } else if (angle_mouse > 45 && angle_mouse < 145){
            playerAnim.SetTrigger("left");
            //Debug.Log("esquerda");
        }else{
            playerAnim.SetTrigger("down");
            //Debug.Log("costa");
        }
    }

    void AngleCalc(){
        mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
        shoot_direction = mouse_position - playerRb.position;
        angle = playerRb.rotation;
        angle_mouse = (Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90)- angle;
    }
    public void Take_Damage(int DAMAGE){
        hp.SetHealth(DAMAGE);
        myHealth -=DAMAGE;
        if(myHealth <= 0){
            Dead();
        }
    }
    private void Dead(){
        gameObject.SetActive(false);
    }
}
