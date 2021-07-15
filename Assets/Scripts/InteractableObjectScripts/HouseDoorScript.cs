using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoorScript : MonoBehaviour
{
    //public GameObject ExitDoor;
    public Animator animator;

    public void Interact()
    {
        animator.SetBool("HouseDoorUnlocked", true);
    }
}
