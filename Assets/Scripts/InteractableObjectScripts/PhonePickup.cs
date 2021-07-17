/******************************************************************************
Authors: Phil & Elicia
Name of Class: PhonePickUp
Description of Class: Player can pick up phone to check for missions
Date Created: 15/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePickup : MonoBehaviour
{
    public GameObject phone_object;
    public Animator animate;
    public AudioSource notification;
    public Animator objectiveUI;

    public void Interact()
    {
        phone_object.SetActive(false);
        animate.SetBool("PhoneTakeOut", true);
        
        objectiveUI.SetBool("ObjectiveUpdate", true);
    }
}
