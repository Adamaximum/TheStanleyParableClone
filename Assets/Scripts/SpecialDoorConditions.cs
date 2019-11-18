using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: on the Player object
// PURPOSE: apply special conditions to certain triggers when colliding with them
public class SpecialDoorConditions : MonoBehaviour
{
    public GameObject leftDoorTrigger;
    public EventTrigger lastTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerRightDoor") // Destroys the left door trigger so it isn't a problem anymore
        {
            Destroy(leftDoorTrigger.gameObject);
        }

        if (other.gameObject.tag == "TriggerRepeating") // "Untriggers" the last trigger and replaces it with a new one
        {
            if (lastTrigger != null && lastTrigger.name != other.gameObject.name)
            {
                lastTrigger.triggered = false;
            }
            lastTrigger = other.gameObject.GetComponent<EventTrigger>();
        }
    }
}
