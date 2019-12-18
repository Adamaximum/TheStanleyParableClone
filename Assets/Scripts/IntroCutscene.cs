using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public SpriteRenderer blackout;

    public bool fadeIn;
    public int movementPhases;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        blackout = GetComponentInChildren<SpriteRenderer>();

        //StartCoroutine(CameraPath());
    }

    // Update is called once per frame
    void Update()
    {
        //if (fadeIn)
        //{
        //    blackout.color -= new Color(0, 0, 0, 0.005f);
        //}
        //else
        //{
        //    blackout.color += new Color(0, 0, 0, 0.005f);
        //}

        if (manager.currentLine == 3)
        {
            
            movementPhases = 1;
        }

        if (movementPhases == 1)
        {
            transform.position -= new Vector3(0.004f, 0f, 0f);

            if (transform.position.x > 6.8f)
            {
                blackout.color -= new Color(0, 0, 0, 0.01f);
            }
            else if (transform.position.x <= 6.8f)
            {
                blackout.color += new Color(0, 0, 0, 0.01f);
            }
        }

        //else if (manager.currentLine == 4)
        //{
        //    if (movementPhases == 0)
        //    {
        //        blackout.color += new Color(0, 0, 0, 0.005f);
        //        if (blackout.color.a == 255)
        //        {
        //            movementPhases = 1;
        //        }
        //    }
        //    else if (movementPhases == 1)
        //    {
        //        blackout.color -= new Color(0, 0, 0, 0.005f);
        //    }
        //}




    }

    //IEnumerator CameraPath()
    //{
    //    yield return new WaitForSeconds(5);

    //    fadeIn = true;

    //    yield return new WaitForSeconds(8);

    //    fadeIn = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerNormal")
        {
            
        }

        Debug.Log("Triggered!");
    }
}
