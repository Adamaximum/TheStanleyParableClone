﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// USAGE: place on the Main Camera in the Mariella Cutscene
// PURPOSE: to operate the camera's movements during the cutscene according to the DialogueManager's line
public class MariellaCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public SpriteRenderer fade;

    public TextMeshProUGUI centerTitle;

    bool displayCredits;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        fade = GetComponentInChildren<SpriteRenderer>();

        centerTitle = GameObject.Find("CenterTitle").GetComponent<TextMeshProUGUI>();

        centerTitle.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentLine > 2) // Camera begins rising
        {
            transform.localPosition += new Vector3(0, 0.1f, 0) * Time.deltaTime;
        }

        if (manager.currentLine > 2 && manager.currentLine < 9) // Camera fades in
        {
            fade.color -= new Color(0, 0, 0, 0.005f);
        }
        else if (manager.currentLine > 9) // Camera blacks out
        {
            fade.color = new Color(0, 0, 0, 255);

            if (displayCredits == false)
            {
                StartCoroutine(CreditsDisplay());
                displayCredits = true;
            }
        }
    }

    IEnumerator CreditsDisplay()
    {
        Debug.Log("Roll credits!");

        centerTitle.text = "";

        yield return new WaitForSeconds(2);

        centerTitle.text = "Written and created by Davey Wreden";

        yield return new WaitForSeconds(5);

        centerTitle.text = "";

        yield return new WaitForSeconds(1);

        Debug.Log("Now restart!");

        SceneManager.LoadScene(0);
    }
}
