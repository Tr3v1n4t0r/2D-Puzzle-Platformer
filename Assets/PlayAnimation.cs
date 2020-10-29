using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform diskPos;

    private Animation anim;

    private bool playerDetected;

    public float width;
    public float height;

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(diskPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if (playerDetected == true)
        {
            anim["playSpin"].enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(diskPos.position, new Vector3(width, height, 1));
    }
}
