using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int dmg;
    public float pushPower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }   

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerCharacter>().Take_Damage(dmg); 
        }else if(other.CompareTag("Enemy")){
            other.GetComponent<EnemyMob>().Take_Damage(dmg);
            Vector2 dif = other.transform.position - transform.position;
            dif = dif.normalized * pushPower;
            other.GetComponent<Rigidbody2D>().AddForce(dif,ForceMode2D.Impulse);
        }
        // if(other.CompareTag("Enemy")){
        //     other.GetComponent<EnemyMob>().Take_Damage(dmg);
        // }else{
        //     other.GetComponent<PlayerCharacter>().Take_Damage(dmg);
        // }
    }
    private void PushBack(Rigidbody2D RIG){

    }
}
