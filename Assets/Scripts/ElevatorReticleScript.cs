using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// USAGE: Put this on the player character with the appropriate canvas. 
// NOTE: Add a trigger collider in the elevator and set tag "InElevator."
// FUNCTION: Makes the reticle appear when the player is standing in the elevator.
public class ElevatorReticleScript : MonoBehaviour
{
    public Collider reticleTrigger;
    public GameObject reticleText;

    void Start() {
        reticleText.SetActive(false);
        //Debug.Log(reticleTrigger.tag);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "InElevator") {
            reticleText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "InElevator") {
            reticleText.SetActive(false);
        }
    }
}
