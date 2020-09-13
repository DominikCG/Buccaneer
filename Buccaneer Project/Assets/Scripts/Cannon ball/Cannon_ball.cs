using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_ball : MonoBehaviour
{

    [SerializeField] private GameObject explosion_effect = default;
    [SerializeField] private int damage = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit_obj = collision.gameObject;

        if (hit_obj.CompareTag("Enemy"))
        {
           hit_obj.gameObject.GetComponent<Enemy>().takeDamage(damage);


            GameObject effect = Instantiate(explosion_effect, transform.position, Quaternion.identity);
            Destroy(effect,0.5f);
            Destroy(gameObject);
        }
        else
        {
            GameObject effect = Instantiate(explosion_effect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
        
    }

    public void SetBallDamage(int _damage)
    {
        damage = _damage;
        Debug.Log(_damage);
        Debug.Log(damage);
    }
}
