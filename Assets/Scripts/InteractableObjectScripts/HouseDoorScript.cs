/******************************************************************************
Authors: Phil & Elicia
Name of Class: HouseDoorScript
Description of Class: Opens the door of the house to the next scene, Island
Date Created: 12/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoorScript : MonoBehaviour
{
    //public GameObject ExitDoor;
    public Animator animator;
    public AudioSource sound;

    public void Interact()
    {
        sound.Play();
        Invoke("playAnimation", 2f);
    }

    void playAnimation()
    {
        animator.SetBool("HouseDoorUnlocked", true);
    }
}

