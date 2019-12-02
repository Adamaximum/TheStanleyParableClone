using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// USAGE: on the Player object
// PURPOSE: this is a Dev Tool that jumps the Player to certain endings before playing
public class JumpToEnding : MonoBehaviour
{
    public string cheatCode;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (cheatCode == "Insane")
        {
            transform.position = new Vector3(45f, -5.84f, 71.2f);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        }
        if (cheatCode == "Elevator")
        {
            transform.position = new Vector3(60.18f, transform.position.y, 20.625f);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        }
        if (cheatCode == "RedBlue")
        {
            transform.position = new Vector3(58.26f, -9.28f, 35.6f);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        }
    }
}
