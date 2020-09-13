using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{

    [SerializeField] private int max_health = 100;
    [SerializeField] private int current_health = 0;

    public Health_bar health_Bar;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        health_Bar.SetMaxHealth(max_health);
    }

    public void takeDamage(int damage)
    {
        current_health -= damage;
        health_Bar.SetHealth(current_health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
