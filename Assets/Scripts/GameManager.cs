using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject text;
    // [SerializeField]
    // private GameObject mainUI;
    // [SerializeField]
    // private GameObject coverPanel;
    // [SerializeField]
    // private GameObject startPanel;

    private string txt = "";
    [SerializeField] private TMP_Text m_TextComponent;


    // public string GameMode { get => gameMode; set => gameMode = value; }

    [SerializeField] Animator textUI;
    bool canOpen = false;
    bool canChange = false;

    //make it a singleton to not exist in other scenes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // mainUI.SetActive(true);
        // GameObject.DontDestroyOnLoad(this);
        // PlayAgain(true);
    }

    // Update is called once per frame
    void Update()
    {
        // if (startPanel.activeSelf) {
        // }
        if(canOpen){

        if (Input.GetKeyDown("e"))
        {
                text.SetActive(true);
                m_TextComponent.text = txt;
            }
        }
        if (Input.GetKeyDown("escape")){
           //textUI.SetBool("show",false);
           text.SetActive(false);
       }
        if(canChange){

        if (Input.GetKeyDown("e"))
        {
           SceneManager.LoadScene(txt);
        }
        }
    }

    public void StartGame()
    {
        // startPanel.SetActive(false);
        // arrowNextRoom.SetActive(true);
        // //active too other 2 topbar btns

        // topBarPlayAgainBtn.SetActive(true);
        // SwitchScene(0);
    }
    public void SetInteraction(bool STATE){
        canOpen = STATE;
    }
    public void SetCanChange(bool STATE){
        canChange = STATE;
    }
    public void AllowArrowToNextScene(bool STATE)
    {
        //if ((selectedScene < rooms.Length - 1 && STATE) || !STATE)
        //{
        //    arrowNextRoom.GetComponent<Animator>().SetBool("show", STATE);
        //}
        //else if (selectedScene < rooms.Length && STATE)
        //{
            //show end game btn
        //}
        
    }

    public void ArrowsSwitchScene(bool NEXT = true) {
        // if (NEXT) {
        //     selectedScene++;
        //     AllowArrowToNextScene(false);
        // }

    }
    public void SetText(string newTxt){
        txt = newTxt;
    }
    private void SetPreResult(){
        //preResutPanel.SetActive(true);
    }
   
    public void SwitchScene(int SCENE) {
        
    }

    public void ActiveScene()
    {

    }

    public void PlayAgain(bool ANSWERBOX = true)
    {

    }

    public void SceneChange(int ID) {
        SoundManager.instance.MusicChange(ID);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
