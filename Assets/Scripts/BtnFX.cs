/******************************************************************************
Authors: Phil & Elicia
Name of Class: BtnFX
Description of Class: Button Sounds
Date Created: 17/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFx;

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
