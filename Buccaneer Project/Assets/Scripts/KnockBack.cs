using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
[SerializeField] float knockPower;

[SerializeField] float knockTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null){
                Vector2 diff = enemy.transform.position - transform.position;
                diff = diff.normalized * knockPower;
                enemy.AddForce(diff,ForceMode2D.Impulse);
                StartCoroutine(KnockBackTimeCo(enemy));
            }
        }
    }
    private IEnumerator KnockBackTimeCo(Rigidbody2D enemy){
        if(enemy != null){
            yield return new WaitForSeconds(knockTimer);
            enemy.velocity = Vector2.zero;
        }
    }
}
