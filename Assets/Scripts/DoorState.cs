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

    bool doorClosed;

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, openAngle, transform.localEulerAngles.z);
        }
        else
        {
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, closeAngle, transform.localEulerAngles.z);
            if (!doorClosed)
            {
                StartCoroutine(doorMovement());
            }
        }
    }

    IEnumerator doorMovement()
    {
        doorClosed = true;
        float tracksTime = 0;

        while (tracksTime < 0.5f)
        {
            tracksTime += Time.deltaTime;
            
            

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 
                Mathf.Lerp(openAngle, closeAngle, tracksTime / 0.5f), transform.localEulerAngles.z);

            yield return null;


        }
    }
}
