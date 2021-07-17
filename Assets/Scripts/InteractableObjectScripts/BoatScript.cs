/******************************************************************************
Authors: Phil & Elicia
Name of Class: BoatScript
Description of Class: Player can fix propeller on boat and escape island 
Date Created: 16/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    //public GameObject propeller;
    public GameObject FadeScene;
    public AudioSource sound;
    public Animator boat;

    public void Interact()
    {
        sound.Play();
        boat.SetTrigger("Start");
        StartCoroutine(DoFadeIn());
        IEnumerator fadeSound1 = AudioFadeOut.FadeOut(sound, 4f);
        StartCoroutine(fadeSound1);
        //StopCoroutine(fadeSound1);
    }

    IEnumerator DoFadeIn()
    {
        yield return new WaitForSeconds(12);
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
        yield return null;

    }

    public static class AudioFadeOut
    {

        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            yield return new WaitForSeconds(12);
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }

    }
}
