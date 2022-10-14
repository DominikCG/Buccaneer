using System.Collections.Generic;
using UnityEngine;

public enum AudioClipID
{
    LevelBGM, //Fazer lista de sons mais para frente;
    CannonSfx,
    ShipSfx,
    ButtonPress,
}

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    private class AudioData
    {
        public AudioClipID ID;
        public AudioClip audioClip;
        public AudioSource audioSource;

        [Range(0f, 1f)]
        public float volume;
        public bool loop;
    }

    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<AudioData> audioDataList;

    private void Awake()
    {
        Instance = this;

        foreach(AudioData audioData in audioDataList)
        {
            audioData.audioSource = gameObject.AddComponent<AudioSource>();
            audioData.audioSource.clip = audioData.audioClip;
            audioData.audioSource.volume = audioData.volume;
            audioData.audioSource.loop = audioData.loop;
        }
    }

    private void Start()
    {
        PlayAudio(AudioClipID.LevelBGM);
    }

    public void PlayAudio(AudioClipID audioID)
    {
        AudioData audioData = audioDataList.Find(data => data.ID == audioID);

        if(audioData == null)
        {
            return;
        }

        AudioSource audioSource = audioData.audioSource;
        audioSource.Play();
    }

    public void PlayAudio(AudioClip narrationClip)
    {
        AudioData audioData = audioDataList.Find(data => data.ID == AudioClipID.CannonSfx);

        if(audioData == null)
        {
            return;
        }

        audioData.audioClip = narrationClip;
        audioData.audioSource.clip = narrationClip;

        AudioSource audioSource = audioData.audioSource;
        audioSource.Play();
    }

    public void StopAudio(AudioClipID audioID) //Fazer Fade no Audio;
    {
        AudioData audioData = audioDataList.Find(data => data.ID == audioID);
        audioData.audioSource.Stop();
    }
}