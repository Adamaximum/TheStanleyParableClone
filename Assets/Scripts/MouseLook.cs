using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float verticalAngle = 0f; // store vertical look in a separate variable
    // so as to avoid eulerAngles wraparound from 180 to -180
    

    // Update is called once per frame
    void Update()
    {
        // returns "0" if we aren't moving the mouse
        float mouseX = Input.GetAxis("Mouse X"); // horizontal mouse velocity
        float mouseY = Input.GetAxis("Mouse Y"); // vertical mouse velocity

        transform.parent.Rotate(0f, mouseX * 10f, 0f); // rotate camera's parent (cube)

        verticalAngle -= mouseY * 10f;
        verticalAngle = Mathf.Clamp(verticalAngle,-80f,80f);

        // X = Pitch, Y = Yaw, Z = Roll
        transform.localEulerAngles = new Vector3(verticalAngle,
                                                 transform.localEulerAngles.y,
                                                 0f);
    }
}
