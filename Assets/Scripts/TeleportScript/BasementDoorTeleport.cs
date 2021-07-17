/******************************************************************************
Authors: Phil & Elicia
Name of Class: BasementDoorTeleport
Description of Class: Player can teleport to the house from this door
Date Created: 13/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorTeleport : MonoBehaviour
{
    public GameObject FadeScene;
    public GameObject playerObject;
    public Transform teleportTarget;

    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
        yield return null;

    }

    IEnumerator DoFadeOut()
    {
        yield return new WaitForSeconds(2);
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
        yield return null;

    }


    private void TeleportPlayer()
    {
        playerObject.transform.position = teleportTarget.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DoFadeIn());
        StartCoroutine(DoFadeOut());
        Invoke("TeleportPlayer", 1.2f);
        Debug.Log("Teleporting...");
    }
}

