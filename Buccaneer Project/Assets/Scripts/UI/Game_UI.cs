using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Game_UI : MonoBehaviour
{
    [SerializeField] private GameObject end_game = default;
    [SerializeField] private GameObject game_info = default;
    [SerializeField] private Text score_txt = default;
    [SerializeField] private Text timer_txt = default;
    [SerializeField] private Text end_game_txt = default;
    [SerializeField] private Text end_game_score_txt = default;
    [SerializeField] private int score_value = default;
    private float timer = default;
    private int score = default;
    private bool player_is_alive = default;
    private bool pause_game = default;

    private void Start()
    {
        pause_game = false;
        Time.timeScale = 1;
        timer = 0;
        // timer = Game_Configurations.Config.Get_Game_Time();
    }

    private void Update()
    {
        Count_Up();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_game = !pause_game;
            Pause_Game();
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

    public void Victory()
    {
        Time.timeScale = 0;
        end_game.SetActive(true);
        game_info.SetActive(false);
        end_game_txt.text = "Victory!";
        end_game_score_txt.text = "Final Score: " + score;
    }

    private void Pause_Game()
    {
        if (pause_game)
        {
            end_game.SetActive(true);
            game_info.SetActive(false);
            end_game_txt.text = "Menu";
        }
        else
        {
            end_game.SetActive(false);
            game_info.SetActive(true);
            end_game_txt.text = " ";
        }
    }

    private void Count_Up()
    {
        timer += Time.deltaTime;
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

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Player_is_alive(bool is_alive)
    {
        player_is_alive = is_alive;
    }

}
