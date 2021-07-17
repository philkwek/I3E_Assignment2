/******************************************************************************
Authors: Phil & Elicia
Name of Class: BoltScript
Description of Class: Audio sound of bolt cutters and player can pick up object
Date Created: 17/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
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
