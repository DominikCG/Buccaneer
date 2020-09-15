﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{

    [SerializeField] private int max_health = default;
    [SerializeField] private int current_health = default;
    [SerializeField] private Sprite[] ship_sprite = default;

    public Health_bar health_Bar = default;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        health_Bar.SetMaxHealth(max_health);
        Set_Sprite();
    }

    private void Set_Sprite()
    {
        if (current_health > 75)
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[0];
        if (current_health > 50 && current_health < 75)
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[1];
        if (current_health > 25 && current_health < 50)
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[2];
        if (current_health <= 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = ship_sprite[3];
    }

    public void Take_Damage(int damage)
    {
        current_health -= damage;
        health_Bar.SetHealth(current_health);
        Set_Sprite();
    }

}
