using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventPlay : MonoBehaviour
{
    public void TurnAudio()
    {
        SoundManager.instance.TurnAudio();
    }

    public void PlayClick()
    {
        SoundManager.instance.PlayMouseClick();
    }
    public void PlayClickMid()
    {
        SoundManager.instance.PlayMouseClickMid();
    }

    public void PlayOverBtn()
    {
        SoundManager.instance.PlayMouseOverBtn();
    }

    public void PlayOverList()
    {
        SoundManager.instance.PlayMouseOverList();
    }

    public void PlayDrag()
    {
        SoundManager.instance.PlayDrag();
    }

    public void PlayValueChange()
    {
        SoundManager.instance.PlayValueChange();
    }

    public void PlayclickObject()
    {
        SoundManager.instance.PlayClickSceneObject();
    }
}
