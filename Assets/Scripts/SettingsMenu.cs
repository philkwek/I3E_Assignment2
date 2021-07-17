/******************************************************************************
Authors: Phil & Elicia
Name of Class: SettingsMenu
Description of Class: Changes the volume of the BGM & Effects
Date Created: 14/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Adding audio changing effects to the scene 
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer effectsMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetEffects(float effects)
    {
        effectsMixer.SetFloat("effects", effects);
    }
}
