using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    [SerializeField] private Slider slider = default;

    public void SetMaxHealth(int max_health)
    {
        slider.maxValue = max_health;
        slider.value = max_health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
