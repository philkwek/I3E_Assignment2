/******************************************************************************
Authors: Phil & Elicia
Name of Class: DockTrigger
Description of Class: Player gets notified of new mission whenreached dock
Date Created: 15/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockTrigger : MonoBehaviour
{
    bool ringtone = false;
    private void OnTriggerEnter(Collider other)
    {
        if (ringtone == false)
        {
            other.gameObject.GetComponent<PlayerScript>().activateObjective4();
            ringtone = true;

        }
        
    }
}
