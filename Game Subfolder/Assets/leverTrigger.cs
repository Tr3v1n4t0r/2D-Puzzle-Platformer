using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverTrigger : MonoBehaviour
{
    public Sprite LeverOn;
    public GameObject other;

    // Update is called once per frame
    void Update()
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().sprite == LeverOn)
        {
            Destroy(gameObject);
            Destroy(this);
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
