using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverTrigger : MonoBehaviour
{
    public Sprite LeverOn;    // Public attribute used to "see" a specific sprite
    public GameObject other;    // Public attribute used to view the lever game object

    // Update is called once per frame
    void Update()
    {
        // Checks to see if the lever game object is in the "on" position
        if (other.gameObject.GetComponent<SpriteRenderer>().sprite == LeverOn)
        {
            // When the lever is "on", the gate that this object that this function is attached to is deleted
            Destroy(gameObject);
            // "this" refers to this file (might be unnecessary)
            Destroy(this);
            // The "Rigidbody" refers to the hitbox of the current object (might be unnecessary)
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
