using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: on the Player object
// PURPOSE: apply special conditions to certain triggers when colliding with them
public class SpecialDoorConditions : MonoBehaviour
{
    public GameObject leftDoorTrigger;

    public EventTrigger lastTrigger;

    public Transform[] teleportDestination;
    public int teleportNumber;

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

        if (other.gameObject.tag == "TriggerTeleport")
        {
            transform.position = new Vector3 (teleportDestination[teleportNumber].position.x, 
                teleportDestination[teleportNumber].position.y, teleportDestination[teleportNumber].position.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
            //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            teleportNumber++;
        }
    }
}
