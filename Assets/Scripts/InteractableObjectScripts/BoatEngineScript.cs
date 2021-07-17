/******************************************************************************
Authors: Phil & Elicia
Name of Class: BoatEngineScript
Description of Class: Plays sound of boat engine
Date Created: 17/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEngineScript : MonoBehaviour
{
    public GameObject propeller;
    public AudioSource sound;

    public void Interact()
    {
        sound.Play();
        propeller.SetActive(true);
    }
}
