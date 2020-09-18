using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Game_UI : MonoBehaviour
{

   
    [SerializeField] private Text score_txt = default;
    [SerializeField] private Text timer_txt = default;
    [SerializeField] private Text end_game_txt = default;
    [SerializeField] private Text end_game_score_txt = default;
    [SerializeField] private GameObject end_game = default;
    [SerializeField] private GameObject game_info = default;
    
    private float timer = default;
    [SerializeField] private int score_value = default;
    private int score = default;
    private bool player_is_alive = default;

    private void Start()
    {
        Time.timeScale = 1;
        timer = Game_Configurations.Config.Get_Game_Time();
        
    }

    private void Update()
    {
        Count_Down();

        if(timer <= 0 && player_is_alive)
        {
            Victory();
        }
        if (!player_is_alive)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        end_game.SetActive(true);
        game_info.SetActive(false);
        end_game_txt.text = "Defeated!";
        end_game_score_txt.text = "Final Score: " + score;
    }

    private void Victory()
    {
        Time.timeScale = 0;
        end_game.SetActive(true);
        game_info.SetActive(false);
        end_game_txt.text = "Victory!";
        end_game_score_txt.text = "Final Score: " + score;
    }

    private void Count_Down()
    {
        timer -= Time.deltaTime;
        timer_txt.text = timer.ToString("F0") + " Seconds";
    }

    public void Set_score()
    {
        score += score_value;
        score_txt.text = "Score: " + score;
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Main_menu()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void Player_is_alive(bool is_alive)
    {
        player_is_alive = is_alive;
    }

}
