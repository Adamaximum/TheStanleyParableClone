using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: on the Player object
// PURPOSE: this is a Dev Tool that jumps the Player to certain endings before playing
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
}
