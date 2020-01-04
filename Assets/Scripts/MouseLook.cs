using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float horizontalLookSpd = 0;
    public float verticalLookSpd = 0;

    float verticalAngle = 0f; // store vertical look in a separate variable
    // so as to avoid eulerAngles wraparound from 180 to -180
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked; // locks cursor to center of screen (** NEEDED for Interaction Script **)
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X"); // horizontal mouse velocity
        float mouseY = Input.GetAxis("Mouse Y"); // vertical mouse velocity

        transform.parent.Rotate(0f, mouseX * horizontalLookSpd * Time.deltaTime, 0f); // rotate player

        verticalAngle -= mouseY * verticalLookSpd * Time.deltaTime; // change the vertical angle
        verticalAngle = Mathf.Clamp(verticalAngle, -90f, 90f); // clamp the vertical so the player can't bend over

        transform.localEulerAngles = new Vector3(verticalAngle,
                                                 transform.localEulerAngles.y,
                                                 0f); // change the camera angle
    }
}
