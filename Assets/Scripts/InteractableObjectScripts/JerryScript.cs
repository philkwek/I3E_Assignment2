/******************************************************************************
Authors: Phil & Elicia
Name of Class: JerryScript
Description of Class: Allows player to pick up jerrycan for the boat
Date Created: 16/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryScript : MonoBehaviour
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
