using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: Put this on an object that the player will interact with.
// FUNCTION: This object will run Activate() once the player presses E on it.

// ** NOTE: There is CUSTOM CODE in this script. Whatever object this is placed on, the custom code will be specific to that object!!! 
public class ReceiverScript : MonoBehaviour
{
    public AudioSource activatedSource;
    public bool isActivated;
    private bool played = false;

    [Header("ELEVATOR STUFFS")]
    public GameObject elevator; // the elevator
    public ElevatorDoor[] elevatorDoors;

    void Start() {
        isActivated = false;
        activatedSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated && !played) {
            // [[[[[THIS OBJECT'S CUSTOM CODE STARTS HERE]]]]]
            elevator.GetComponent<elevatorScript>().MoveDown();
            for (int i = 0; i < elevatorDoors.Length; i++)
            {
                elevatorDoors[i].doorOpen = false;
            }
            //
            Debug.Log("Button is Activated. Commence code now!");
            activatedSource.PlayOneShot(activatedSource.clip);
            played = true;
        } else {
            //Debug.Log("Waiting...");
        }
    }
}
