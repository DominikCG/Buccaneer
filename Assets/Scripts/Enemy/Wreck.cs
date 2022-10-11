using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreck : MonoBehaviour
{
    [SerializeField] private float duration = 5.0f;
    [SerializeField] private float time_to_despawn = default;
    private SpriteRenderer sprite;
    private float timer_death = default;
    private float startTime;
    private float minimum = 0.0f;
    private float maximum = 1f;
    private float time_to_destroy;
    private bool start_time_set;

    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        start_time_set = false;
        time_to_destroy = time_to_despawn + duration + 1;
    }

    void Update()
    {
        Timer_Control();
    }

    private void Timer_Control()
    {
        timer_death += Time.deltaTime;
        if (timer_death > time_to_despawn)
        {
            if (!start_time_set)
            {
                start_time_set = true;
                startTime = Time.time;
            }

            float t = (Time.time - startTime) / duration;
            sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(maximum, minimum, t));
            
            if (timer_death > time_to_destroy)
            {
                Destroy(gameObject);
            }

        }
    }

}