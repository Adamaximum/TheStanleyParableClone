using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public bool movingDown = false; // indicate if the elevator is moving
    public bool movingUp = false;
    private Vector3 elevatorPos; // to store the elevator's position
    public float elevatorYDestinationDown; // the y axis of destination for the elevator to go down
    public float elevatorMoveSpd;
    public float elevatorYDestinationUp; // the y axis of detination for the elevator to go up

    // Start is called before the first frame update
    void Start()
    {
        elevatorPos = transform.position; // store elevator position to elevatorPos
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDown){
            elevatorPos.y -= elevatorMoveSpd * Time.deltaTime; // if moving is true, decrease
            transform.position = elevatorPos; // change elevator actual position
        }
        if (movingDown && transform.position.y <= elevatorYDestinationDown){ // if elevator is lower or equal to desired y position
            movingDown = false; // stop moving down
        }

        if (movingUp){
            elevatorPos.y += elevatorMoveSpd * Time.deltaTime; // go up
            transform.position = elevatorPos; // actually go up
        }

        if (movingUp && transform.position.y >= elevatorYDestinationUp){ // if elevator is above or equal to the desired y position
            movingUp = false; // stop moving up
        }
    }

    public void MoveUp(){
        movingUp = true;
    }

    public void MoveDown(){
        movingDown = true;
    }
}