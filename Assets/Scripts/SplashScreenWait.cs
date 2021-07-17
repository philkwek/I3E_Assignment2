/******************************************************************************
Authors: Phil & Elicia
Name of Class: SplashScreenWait
Description of Class: Plays at the start of the game application 
Date Created: 14/07/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenWait : MonoBehaviour
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
        Menu.SetActive(true);


    }
}
