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
    // [SerializeField]
    // private GameObject topBarPlayAgainBtn;

    // private int selectedScene = 0;
    // [SerializeField]

    // private GameObject arrowNextRoom;
    // [SerializeField]
    // private GameObject preResutPanel;
    // [SerializeField]
    // private GameObject resutPanel;
    // [SerializeField, TextArea]
    // private string[] feebacksStr;
    // [SerializeField]
    // private TextMeshProUGUI feebacksTMPro;
    // [SerializeField]
    // private Sprite[] endImages;
    // [SerializeField]
    // private Image endImage;
    // [SerializeField]

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
        // selectedScene = SCENE;

        // //Debug.Log(selectedScene);
        // switch (selectedScene)
        // {
        //     case 0:
        //         ActiveScene();
        //         break;

        //     case 1:
        //         ActiveScene();
        //         //optionSelect.ResetComponent();

        //         //sem alterar
        //         break;

        //     case 2:
        //         ActiveScene();
        //         break;

        //     case 3:
        //         ActiveScene();
        //         break;

        //     case 4:
        //         ActiveScene();
        //         break;

        //     case 5:
        //         ActiveScene();
        //         break;

        //     case 6:
        //         ActiveScene();
        //         break;

        //     case 7:
        //         ActiveScene();
        //         break;

        //     case 8:
        //         ActiveScene();
        //         break;
        //     case 9:
        //         ActiveScene();
        //         break;

        //     case 10:
        //         ActiveScene();
        //         break;

        //     case 11:
        //         ActiveScene();
        //         break;

        //     case 12:
        //         ActiveScene();
        //         break;

        //     case 13:
        //         ActiveScene();
        //         break;

        //     case 14:
        //         ActiveScene();
        //         break;

        //     case 15:
        //         ActiveScene();
        //         break;
        //     case 16:
        //         ActiveScene();
        //         break;

        //     case 17:
        //         ActiveScene();
        //         break;

        //     case 18:
        //         ActiveScene();
        //         break;

        //     case 19:
        //         ActiveScene();
        //         break;

        //     case 20:
        //         ActiveScene();
        //         break;

        //     case 21:
        //         ActiveScene();
        //         break;

        //     case 22:
        //         ActiveScene();
        //         break;
        // }
    }

    public void ActiveScene()
    {

        // if (selectedScene > 0)
        // {
        //     // rooms[selectedScene - 1].ShowOrHideTextBox(false);
        //     // rooms[selectedScene].ShowOrHideTextBox(true);
        // }
        // else
        // {
        // }      
    }

    public void PlayAgain(bool ANSWERBOX = true)
    {
        // if (ANSWERBOX) {

        //     coverPanel.SetActive(true);
        //     startPanel.SetActive(true);
        //     arrowNextRoom.SetActive(false);
        //     preResutPanel.SetActive(false);
        //     resutPanel.SetActive(false);
        //     topBarPlayAgainBtn.SetActive(false);
        //     selectedScene = 0;
            
        // }
    }

    public void SceneChange(int ID) {
        SoundManager.instance.MusicChange(ID);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
