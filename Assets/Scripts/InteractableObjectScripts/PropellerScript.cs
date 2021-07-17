/******************************************************************************
Authors: Phil & Elicia
Name of Class: PropellerScript
Description of Class: Player can pick up propeller and fix it to the boat
Date Created: 16/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerScript : MonoBehaviour
{
    public AudioSource sound;

    public void Interact()
    {
        sound.Play();
        Invoke("disableObject", 0.5f);
    }

    void disableObject()
    {
        gameObject.SetActive(false);
    }
}
