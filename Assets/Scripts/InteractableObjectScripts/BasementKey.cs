using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementKey : MonoBehaviour
{
    public AudioSource sound;

    public void BasementKeyPickup()
    {
        Debug.Log("Picked up key!");
        sound.Play();
        Invoke("disableObject", 0.5f);
    }

    void disableObject()
    {
        gameObject.SetActive(false);
    }
}
