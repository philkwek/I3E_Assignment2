using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementChest : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;
    private bool soundPlayed = false;

    public void Interact()
    {
        animator.SetBool("Activate", true);
        if(soundPlayed == false){
            sound.Play();
            soundPlayed = true;
        }
        
        //add code for playing chest unlock sound
        //opens chest
    }
}
