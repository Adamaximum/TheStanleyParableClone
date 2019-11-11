using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 myInput;
    public float moveSpd;

    private bool grounded = false;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myInput = horizontal * transform.right;
        myInput += vertical * transform.forward;
    }

    void FixedUpdate(){
        if (grounded){
            myRb.velocity = myInput * moveSpd;
        }
        else{
            myRb.velocity = new Vector3(myInput.x * moveSpd, myRb.velocity.y, myInput.z * moveSpd);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "ground"){
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag == "ground"){
            grounded = false;
        }
    }
}
