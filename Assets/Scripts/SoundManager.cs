using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public bool soundStatus = true;
    public static SoundManager instance = null;

    public GameObject soundOn;
    public GameObject soundOff;

    public AudioSource musicAds;
    public AudioSource uiAds;
    public AudioSource sfxAds;
    public AudioSource sfxAmbientAds;

    public AudioSource sfxAux;

    //scene musics
    public AudioClip[] scenesSong = new AudioClip[3];

    //ui
    public AudioClip click;
    public AudioClip clickMid;
    public AudioClip overBtn;
    public AudioClip overList;
    public AudioClip drag;
    public AudioClip valueChange;

    //game
    public AudioClip clickSceneObject;

    [SerializeField] private AudioClip textPopUpSFX;
    [SerializeField] private AudioClip right;
    [SerializeField] private AudioClip wrong;
    //make it a singleton only on scene
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
        GameObject.DontDestroyOnLoad(this);

        if (!soundOn || !soundOff)
        {
            soundOn = GameObject.FindGameObjectWithTag("btnSoundOn");
            soundOff = GameObject.FindGameObjectWithTag("btnSoundOff");

            if (soundStatus)
            {
                soundOn.SetActive(true);
                soundOff.SetActive(false);
            }
            else
            {
                soundOn.SetActive(false);
                soundOff.SetActive(true);
            }
        }

        if (soundStatus)
        {
            TunrOn();
        }
        else
        {
            TunrOf();
        }

        MusicChange(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundOn || !soundOff) {
            soundOn = GameObject.FindGameObjectWithTag("btnSoundOn");
            soundOff = GameObject.FindGameObjectWithTag("btnSoundOff");

            if (soundStatus)
            {
                soundOn.SetActive(true);
                soundOff.SetActive(false);
            }else
            {
                soundOn.SetActive(false);
                soundOff.SetActive(true);
            }

        }
    }

    public void TurnAudio() {
        soundStatus = !soundStatus;
        if (soundStatus == true)
        {
            TunrOn();
        }
        else
        {
            TunrOf();
        }
    }

    private void TunrOf() {
        AudioListener.volume = 0;

        soundOn.SetActive(false);
        soundOff.SetActive(true);

        soundStatus = false;
    }
    private void TunrOn() {

        AudioListener.volume = 0.65f;

        soundOn.SetActive(true);
        soundOff.SetActive(false);

        soundStatus = true;
    }

    public void MusicChange(int ID) {
        musicAds.clip = scenesSong[ID];
        musicAds.Play();
    }

    public void PlayMouseOverList()
    {
        PlayUI(overList);
    }

    public void PlayMouseOverBtn() {
        PlayUI(overBtn);
    }

    public void PlayMouseClick()
    {
        PlayUI(click);
    }
    public void PlayMouseClickMid()
    {
        PlayUI(clickMid);
    }


    public void PlayDrag()
    {
        PlayUI(drag);
    }

    public void PlayValueChange()
    {
        PlayUI(valueChange);
    }

    public void PlayMouseDescription(AudioClip DESCRIPTION)
    {
        PlaySFX(DESCRIPTION);
    }

    public void PlayClickSceneObject()
    {
        PlaySFXAmbient(clickSceneObject);
    }

    private void PlayUI(AudioClip CLIP){
        uiAds.clip = CLIP;
        uiAds.Play();
    }

    private void PlaySFX(AudioClip CLIP)
    {
        if (!sfxAds.isPlaying)
        {
            sfxAds.clip = CLIP;
            sfxAds.Play();
        }
    }
    private void PlaySFXAux(AudioClip CLIP)
    {
            sfxAux.clip = CLIP;
            sfxAux.Play();
    }
    private void PlaySFXAmbient(AudioClip CLIP)
    {
        sfxAmbientAds.clip = CLIP;
        sfxAmbientAds.Play();
    }
    public void PlayPopUpSFX(){
        PlaySFX(textPopUpSFX);
    }

    public void PlayRightAnswer(){
        PlaySFXAux(right);
    }
    public void PlayWrongAnswer(){
        PlaySFXAux(wrong);
    }
}
