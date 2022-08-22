using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuFunctions : MonoBehaviour
{
    // Start is called before the first frame update

    bool isPaused = false;

    public void PauseOrResume()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
