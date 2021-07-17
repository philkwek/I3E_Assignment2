/******************************************************************************
Authors: Phil & Elicia
Name of Class: GameOver
Description of Class: Played when the player ends completes the mission
Date Created: 17/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject SplashScreen; //stop showing splash screen
    public GameObject Menu; //start showing menu
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.5f);
        SplashScreen.SetActive(false);
        SceneManager.LoadScene(0);


    }
}
