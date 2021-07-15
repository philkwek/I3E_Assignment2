using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public Animator animator;
    public void Interact()
    {
        Debug.Log("Door unlocked");
        animator.SetBool("Activate", true);
    }
}
