﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Functions that are accessed by in game buttons
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Debug.Log is used when testing in game
        Debug.Log("QUIT");
        Application.Quit();
    }
}
