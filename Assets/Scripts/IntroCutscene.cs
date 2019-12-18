using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public SpriteRenderer blackout;

    public bool fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        blackout = GetComponentInChildren<SpriteRenderer>();

        StartCoroutine(CameraPath());
    }

    // Update is called once per frame
    void Update()
    {
        //if (manager.currentLine == 2)
        //{
        //    blackout.color -= new Color(0, 0, 0, 0.005f);
        //}

        if (fadeIn)
        {
            blackout.color -= new Color(0, 0, 0, 0.005f);
        }
        else
        {
            blackout.color += new Color(0, 0, 0, 0.005f);
        }
    }

    IEnumerator CameraPath()
    {
        yield return new WaitForSeconds(2);

        fadeIn = true;

        yield return new WaitForSeconds(10);

        fadeIn = false;
    }
}
