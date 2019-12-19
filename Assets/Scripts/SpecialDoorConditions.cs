using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: on the Player object
// PURPOSE: apply special conditions to certain triggers when colliding with them
public class SpecialDoorConditions : MonoBehaviour
{
    public DialogueManager manager;

    [Header("Left Door")]
    public GameObject leftDoorTrigger;

    [Header("Mariella Ending")]
    public EventTrigger lastTrigger;

    [Header("Apartment Ending")]
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

        if (other.gameObject.tag == "TriggerTeleport") // Teleports the player based on the trigger they hit
        {
            transform.position = new Vector3 (teleportDestination[teleportNumber].position.x, 
                teleportDestination[teleportNumber].position.y, teleportDestination[teleportNumber].position.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
            teleportNumber++;
        }
    }
}
