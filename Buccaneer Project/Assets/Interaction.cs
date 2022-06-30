using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Interaction : MonoBehaviour
{
    bool check = false;
    private Vector2 direction = default;
    [SerializeField] private float distance = default;
    [SerializeField] private Vector2 playerPos = default;
    [SerializeField] private string txt;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if(check){
            playerPos = player.position;
            distance = Vector3.Distance(player.position, transform.position);
            if(distance > 2){
            GameManager.instance.SetInteraction(false);
            Debug.Log("saiu");
            check = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            player = other.GetComponent<Rigidbody2D>();
            check = true;
            Debug.Log("entrou");
            GameManager.instance.SetText(txt);
            GameManager.instance.SetInteraction(true);
        }
    }
}
