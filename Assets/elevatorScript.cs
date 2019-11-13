using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{
    public bool moving = false; // indicate if the elevator is moving
    private Vector3 elevatorPos; // to store the elevator's position
    public float elevatorYDestination; // the y axis of destination for the elevator to go
    public float elevatorMoveSpd;

    // Start is called before the first frame update
    void Start()
    {
        elevatorPos = transform.position; // store elevator position to elevatorPos
    }

    // Update is called once per frame
    void Update()
    {
        if (moving){
            elevatorPos.y -= elevatorMoveSpd * Time.deltaTime; // if moving is true, decrease
            transform.position = elevatorPos; // change elevator actual position
        }
        if (transform.position.y <= elevatorYDestination){ // if elevator is lower or equal to desired y position
            moving = false; // stop moving
        }
    }
}
