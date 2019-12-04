using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 myInput;
    public float moveSpd;
    public float slopeFix;

    private bool noDownwardForce = false;

    void Start()
    {
        myRb = GetComponent<Rigidbody>(); // get rigidbody
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // get input
        float vertical = Input.GetAxis("Vertical");

        myInput = horizontal * transform.right; // put the input in a vector3
        myInput += vertical * transform.forward;
    }

    void FixedUpdate(){
        if (!noDownwardForce){
            myRb.velocity = new Vector3(myInput.x * moveSpd, myRb.velocity.y - slopeFix * Time.deltaTime, myInput.z * moveSpd); // when not going up stairs, apply a downward force to keep player on ground
        }
        else{
            myRb.velocity = new Vector3(myInput.x * moveSpd, myRb.velocity.y, myInput.z * moveSpd); // when moving up stairs, take away downward force
            //myRb.velocity = myInput * moveSpd;
       }
    }

    private void OnTriggerStay(Collider other) {
        //print(Vector3.Angle(myRb.velocity, other.transform.right));
        if (other.transform.tag == "GoingUpStairs" && myInput.x == 0 && myInput.z == 0){ // when the player is standing still on a stair
            noDownwardForce = true; // don't apply downward force
            myRb.useGravity = false; // don't use gravity
            myRb.velocity = new Vector3(0,0,0); // just stand still
        }
        else if (other.transform.tag == "GoingUpStairs" && 
                ((Vector3.Angle(myRb.velocity,other.transform.right) < 90) || 
                ((Vector3.Angle(myRb.velocity, other.transform.right) > 90) && Vector3.Angle(myRb.velocity, other.transform.right) < 180))){ // when the player is going up
            noDownwardForce = true; // don't apply downward force
            myRb.useGravity = true; // use gravity
        }
        else{ // basically when the player is going down 
            noDownwardForce = false; // apply a downward force to force the player on ground
            myRb.useGravity = true; // use gravity
        }
    }

    private void OnTriggerExit(Collider other) { //when exit the staircase
        if (other.transform.tag == "GoingUpStairs"){
            noDownwardForce = false; // don't apply downward force
            myRb.useGravity = true; // use gravity
        }
    }
}