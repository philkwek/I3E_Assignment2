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
}
