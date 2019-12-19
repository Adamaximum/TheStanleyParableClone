using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: on ElevatorDoor objects
// PURPOSE: to open (shrink) the elevator doors
public class ElevatorDoor : MonoBehaviour
{
    public bool doorOpen;

    float closeSize = 0.25f;
    float openSize = 1f;
    float speed = 0.01f;

    public float multiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        closeSize *= multiplier;
        openSize *= multiplier;
        speed *= multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            if (transform.localScale.z > closeSize)
            {
                transform.localScale -= new Vector3 (0f, 0f, speed);
            }
            else if (transform.localScale.z < closeSize)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, closeSize);
            }
        }
        else
        {
            if (transform.localScale.z < openSize)
            {
                transform.localScale += new Vector3(0f, 0f, speed);
            }
            else if (transform.localScale.z > openSize)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, openSize);
            }
        }
    }
}
