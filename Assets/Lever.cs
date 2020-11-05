using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite LeverOff;    // Public attribute used to get an in game sprite
    public Sprite LeverOn;    // Public attribute used to get an in game sprite

    private bool playerDetected;    // Bool that is used to detect when a player's hitbox is overlapping a specified location
    private bool diskDetected;    // Bool that is used to detect when a disk's hitbox is overlapping a specified location
    public Transform switchPos;    // A game object that dictates where the center of a square is drawn from
    public float width;    // Signifies the width of the square mentioned above
    public float height;    // Signifies the height of the square mentioned above

    public LayerMask whatIsPlayer;    // Public mask used to define what the player is
    public LayerMask whatIsDisk;    // Public mask used to define what the disk is

    // Update is called once per frame
    private void Update()
    {
        // Sets the bool to true if the "whatIsPlayer" mask overlaps the box drawn in the function OnDrawGizmosSelected
        playerDetected = Physics2D.OverlapBox(switchPos.position, new Vector2(width, height), 0, whatIsPlayer);
        // Sets the bool to true if the "whatIsDisk" mask overlaps the box drawn in the function OnDrawGizmosSelected
        diskDetected = Physics2D.OverlapBox(switchPos.position, new Vector2(width, height), 0, whatIsDisk);

        if (playerDetected == true)
        {
            if (Input.GetButtonDown("Up"))
            {
                // Changes the lever sprite depending on which state it's currently in
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == LeverOn)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = LeverOff;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = LeverOn;
                }
            }
        }

        if (diskDetected == true)
        {
            // Turns the lever on if the disk overlaps it
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LeverOn;
        }
    }

    // Function used to draw a wire box
    private void OnDrawGizmosSelected()
    {
        // Colors the box blue
        Gizmos.color = Color.blue;
        // Draws a Cube based on an in game object and a given width and height (depth doesn't matter since it's a 2D game)
        Gizmos.DrawWireCube(switchPos.position, new Vector3(width, height, 1));
    }
}
