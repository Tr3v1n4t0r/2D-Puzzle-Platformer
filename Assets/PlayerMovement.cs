using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;   // Public attribute used to access the CharacterController file

    public float runSpeed = 40f;    // Default state for the run speed of the controllable character

    float horizontalMove = 0f;  // Attribute used to define how fast the character is moving
    bool jump = false;    // Boolean used to specify whether or not the character is jumping
    bool crouch = false;    // Boolean used to specify whether or not the character is "crouching"

    // Update is called once per frame
    void Update()
    {
        // When the button for forward movement is pushed or unpushed, this value gets updated
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            // Sets boolean to true if the jump button is pushed
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            // Sets boolean to true while the crouch buttin is pushed
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            // Sets boolean to false when the crouch button isn't pushed
            crouch = false;
        }
    }

    void FixedUpdate ()
    {
        // Moves the character based on which buttons are pushed, whether it's sideways movement, jumping , or crouching
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // Sets boolean to false to prevent the character from infinitely jumping
        jump = false;
    }
}
