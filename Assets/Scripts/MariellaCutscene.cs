using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: place on the Main Camera in the Mariella Cutscene
// PURPOSE: to operate the camera's movements during the cutscene according to the DialogueManager's line
public class MariellaCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public SpriteRenderer fade;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        fade = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentLine > 2) // Camera begins rising
        {
            transform.localPosition += new Vector3(0, 0.002f, 0);
        }

        if (manager.currentLine > 2 && manager.currentLine < 9) // Camera fades in
        {
            fade.color -= new Color(0, 0, 0, 0.005f);
        }
        else if (manager.currentLine > 9) // Camera blacks out
        {
            fade.color = new Color(0, 0, 0, 255);
        }
    }
}
