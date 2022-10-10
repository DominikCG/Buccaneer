using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public void New_Game()
    {
        SceneManager.LoadScene("Arena_01");
    }
    public void Alpha_Test()
    {
        SceneManager.LoadScene("TestScene");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    
    public void Configurations()
    {

    }
    public void Back()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
