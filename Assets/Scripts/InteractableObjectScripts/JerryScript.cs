using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryScript : MonoBehaviour
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
