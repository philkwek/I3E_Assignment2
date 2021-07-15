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
