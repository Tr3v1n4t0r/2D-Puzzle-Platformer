using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;    // Boolean used to designate whether or not the game is paused

    public GameObject pauseMenuUI;  // Public object used to display the wanted pause UI

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            // Pauses or unpauses the game when the Escape button is pushed
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Turns off the pause screen
        pauseMenuUI.SetActive(false);
        // Sets the timescale to normal speed
        Time.timeScale = 1f;
        // Sets boolean to false
        GameIsPaused = false;
    }

    void Pause()
    {
        // Turns on the pause screen
        pauseMenuUI.SetActive(true);
        // Sets the timescale to 0 so game objects are unable to move in the background
        Time.timeScale = 0f;
        // Sets boolean to true
        GameIsPaused = true;
    }

    // Funcions that are accessed by in game buttons
    
    public void LoadMenu()
    {
        // Sets timescale to normal speed
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Debug.Log used when testing in game
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
