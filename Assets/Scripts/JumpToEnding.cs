using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToEnding : MonoBehaviour
{
    public string cheatCode;

    // Start is called before the first frame update
    void Start()
    {
        if (cheatCode == "Insane")
        {
            transform.position = new Vector3(47.2f, -6.05f, 94.33f);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
