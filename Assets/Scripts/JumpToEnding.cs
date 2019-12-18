using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// USAGE: on the Player object
// PURPOSE: this is a Dev Tool that jumps the Player to certain endings before playing
public class JumpToEnding : MonoBehaviour
{
    public string cheatCode;

    public Transform[] cheatLocations;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (cheatCode == "Insane")
        {
            transform.position = new Vector3(cheatLocations[0].position.x, cheatLocations[0].position.y, cheatLocations[0].position.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        }
        if (cheatCode == "Elevator")
        {
            transform.position = new Vector3(cheatLocations[1].position.x, cheatLocations[1].position.y, cheatLocations[1].position.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        }
        if (cheatCode == "RedBlue")
        {
            transform.position = new Vector3(cheatLocations[2].position.x, cheatLocations[2].position.y, cheatLocations[2].position.z);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        }
    }
}
