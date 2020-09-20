using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject explosion_effect = default;
    [SerializeField] private GameObject sunk_ship = default;
    [SerializeField] private GameObject UI_aux = default;
    [SerializeField] private Sprite[] ship_sprite = default;
    [SerializeField] private int damage = default;
    [SerializeField] private int max_health = default;
    [SerializeField] private bool is_alive = default;
    private Transform enemy = default;
    private float health_aux = default;
    private int current_health = default;

    public Health_bar health_Bar;

    // Start is called before the first frame update
    void Start()
    {
        is_alive = true;
        UI_aux = GameObject.FindGameObjectWithTag("UI");
        enemy = gameObject.transform;
        current_health = max_health;
        health_Bar.SetMaxHealth(max_health);
        health_aux = max_health / 4;
        Set_Sprite();
    }
  

    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit_obj = collision.gameObject;

        if (hit_obj.CompareTag("Player") && gameObject.CompareTag("Enemy_chaser"))
        {
            hit_obj.gameObject.GetComponent<Player_health>().Take_Damage(damage);
            Death();
        }
    }

    private void Death()
    {
        GameObject enemy_tag = gameObject;
        if (enemy.CompareTag("Enemy_chaser"))
        {
            if(!is_alive)
                UI_aux.GetComponent<Game_UI>().Set_score();

            GameObject effect = Instantiate(explosion_effect, transform.position, Quaternion.identity);
            effect.transform.localScale = effect.transform.localScale * 2f;
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }

        if (enemy.CompareTag("Enemy_shooter"))
        {
            UI_aux.GetComponent<Game_UI>().Set_score();
            GameObject effect = Instantiate(explosion_effect, transform.position, Quaternion.identity);
            effect.transform.localScale = effect.transform.localScale * 2f;
            Instantiate(sunk_ship, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }

    }

    public void Take_Damage(int damage)
    {
        current_health -= damage;
        health_Bar.SetHealth(current_health);
        Set_Sprite();
    }

    private void Set_Sprite()
    {
        if (current_health > health_aux * 3)
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[0];

        if (current_health < health_aux * 3 )
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[1];

        if (current_health < health_aux * 2 )
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[2];

        if (current_health <= 0 && is_alive)
        {
            is_alive = false;
            Death();
        }
        
    }
}
