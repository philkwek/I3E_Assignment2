/******************************************************************************
Authors: Phil & Elicia
Name of Class: BasementDoor
Description of Class: Opens the door when player finds the key to the next scene
Date Created: 13/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;
    public void Interact()
    {
        Debug.Log("Door unlocked");
        sound.Play();
        animator.SetBool("Activate", true);
    }
}
