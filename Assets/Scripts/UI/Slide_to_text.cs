using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide_to_text : MonoBehaviour
{
    [SerializeField] private Slider slider = default;
    private Text value;

    void Start()
    {
        value = GetComponent<Text>();
        Slider_Value();
    }

    public void Slider_Value()
    {
        string slider_value = slider.value + " Seconds";
        value.text = slider_value;
        Save_Config();
    }

    private void Save_Config()
    {
        Debug.Log(gameObject.tag);
        if (gameObject.CompareTag("Spawn_slider_time"))
        {
            Debug.Log(slider.value);
            Game_Configurations.Config.Set_Spawn_Time(slider.value);
        }

        if (gameObject.CompareTag("Game_slider_time"))
        {
            Debug.Log(slider.value);
            Game_Configurations.Config.Set_Game_Time(slider.value);
        }
    }


}
