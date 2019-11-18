using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: place on Door objects
// PURPOSE: to open or close doors at specific angles when called from an EventTrigger
public class DoorState : MonoBehaviour
{
    public bool doorOpen;
    public float openAngle;
    public float closeAngle;

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, openAngle, transform.localEulerAngles.z);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, closeAngle, transform.localEulerAngles.z);
        }
    }
}
