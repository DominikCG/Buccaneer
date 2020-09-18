using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public void New_Game()
    {
        SceneManager.LoadScene("Arena");
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
