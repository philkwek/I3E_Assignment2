using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEngineScript : MonoBehaviour
{
    public GameObject propeller;
    public AudioSource sound;

    public void Interact()
    {
        sound.Play();
        propeller.SetActive(true);
    }
}
