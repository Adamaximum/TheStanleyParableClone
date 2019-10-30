using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody myRb;
    Vector3 myInput;
    public float moveSpd;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Translate does not account fro physics or collision
        // transform.Translate()

        myInput = horizontal * transform.right;
        myInput += vertical * transform.forward;
    }

    void FixedUpdate(){
        // AddForce adds thrust, this is good for spaceships / boats / cars
        //myRb.AddForce(myInput * 15f);
        
        myRb.velocity = myInput * moveSpd;
    }
}
