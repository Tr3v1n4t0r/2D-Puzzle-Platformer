using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite LeverOff;
    public Sprite LeverOn;

    private bool playerDetected;
    public Transform switchPos;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;

    // Update is called once per frame
    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(switchPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if (playerDetected == true)
        {
            if (Input.GetButtonDown("Up"))
            {
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(switchPos.position, new Vector3(width, height, 1));
    }
}
