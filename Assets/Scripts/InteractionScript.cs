using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// USAGE: Put this on a player object who will be interacting with things in game.
// FUNCTION: Allow the player to interact with "Interactable" objects while playing an error sound when the object is not "Interactable."
public class InteractionScript : MonoBehaviour {

    public Transform reticle;

    public AudioSource errorSource;
    public AudioClip errorSound;
    GameObject hitObject;

    //ReceiverScript hitScript;
    //bool hitObjectBool = false;

    void Start()  {

        reticle = GameObject.Find("Reticle").GetComponent<Transform>();

        errorSource.GetComponent<AudioSource>();
        errorSource.clip = errorSound;
    }

    void Update() {
        //cast a ray from the camera to mouse position on screen (** WHICH SHOULD BE LOCKED TO CENTER OF SCREEN bc of MouseLook **)
        Ray mouseRay = Camera.main.ScreenPointToRay(reticle.position);

        float mouseRayDist = 1.0f; // raycast distance (field of view)

        RaycastHit hit = new RaycastHit();

        Debug.DrawRay(mouseRay.origin, mouseRay.direction * mouseRayDist, Color.magenta); //visualize raycast

        if (Input.GetKeyDown(KeyCode.E)) {
            if (Physics.Raycast(mouseRay, out hit, mouseRayDist)) {
                hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Interactable") { //if hit object is interactable...
                    Debug.Log("Interactable!"); //...then this code is run
                                                //what this part should do is "Activate" code from the other object
                        hitObject.GetComponent<ReceiverScript>().isActivated = true;

                } else {
                    errorSource.PlayOneShot(errorSound); //if hit object is not interactable, an error sound plays
                }
            } else {
                errorSource.PlayOneShot(errorSound); //if 'use' key is pressed when not looking at an object at all (so open air), an error sound plays
            }
        }
        
    }
}
