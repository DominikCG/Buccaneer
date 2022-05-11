using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb = default;
    [SerializeField] private float movementSpeed = default;
    [SerializeField] private Vector2 axis = default;



    // Update is called once per frame
    void Update()
    {
        axis.y = Input.GetAxis("Vertical");
        axis.x = Input.GetAxis("Horizontal");
        
    }   

    void FixedUpdate(){

        Move(movementSpeed,axis);      
    }
    private void Move(float ACC, Vector2 DIR)
    {
        playerRb.MovePosition(playerRb.position + DIR * ACC * Time.deltaTime);
    }
}
