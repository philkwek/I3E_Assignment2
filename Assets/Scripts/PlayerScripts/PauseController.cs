using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool isPaused;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
        } else
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        //pause soundfx/bgm
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeactivateMenu()
    {
        //unpause soundfx/bgm
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
