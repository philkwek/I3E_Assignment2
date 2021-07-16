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
