using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;    // Public attribute for scene transition animation

    public float transitionTime = 1f;   // Time between scene change

    private bool playerDetected;    // Bool that is used to detect when a player's hitbox is overlapping a specified location
    public Transform doorPos;   // A game object that dictates where the center of a square is drawn from
    public float width;     // Signifies the width of the square mentioned above
    public float height;    // Signifies the height of the square mentioned above

    public LayerMask whatIsPlayer;     // Public mask used to define what the player is

    private int currentLevel;   // Value used to move to the next scene

    // Start is called at the start of each scene
    public void Start()
    {
        // Grabs the value of the current scene
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    private void Update()
    {
        // Sets the bool to true if the "whatIsPlayer" mask overlaps the box drawn in the function OnDrawGizmosSelected
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);
        
        if (playerDetected == true)
        {
            if (Input.GetButtonDown("Up"))
            {
                // Calls the function to load the next level
                LoadNextLevel();
            }
        }
    }

    // Function used to draw a wire box
    private void OnDrawGizmosSelected()
    {
        // Colors the box blue
        Gizmos.color = Color.blue;
        // Draws a Cube based on an in game object and a given width and height (depth doesn't matter since it's a 2D game)
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }

    // Function called in the Update function
    public void LoadNextLevel()
    {
        // StartCoroutine is a function that uses IEnumerator in order to allow functions to work in tandem. This is used to load the next level
        // while an animation is playing, using the current scene number and adding one to it, since the levels are arranged in numerical order
        StartCoroutine(LoadLevel(currentLevel + 1));
    }

    // Function called in the previous function
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
