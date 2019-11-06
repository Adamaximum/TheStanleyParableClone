using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public bool doorOpen;
    public float openAngle;
    public float closeAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, openAngle, transform.localEulerAngles.z);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, closeAngle, transform.localEulerAngles.z);
        }
    }
}
