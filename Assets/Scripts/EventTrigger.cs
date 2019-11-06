﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public DialogueManager manager;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;
    public GameObject[] doors;

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            manager.PlayVoice();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true; // Ensures this trigger won't start again
            manager.source.Stop(); // Stops current audio
            manager.currentLine = 0; // Resets current line
            manager.subtitleTexts.Clear(); // Clears current set of subtitles
            manager.voiceOverLines.Clear(); // Clears current set of lines
            manager.subtitleTexts.AddRange(subtitleTexts); // Adds new subtitles
            manager.voiceOverLines.AddRange(voiceOverLines); // Adds new lines

            if (manager.currentTrigger != null)
            {
                Destroy(manager.currentTrigger); // Destroys the old trigger
            }
            manager.currentTrigger = this.gameObject; // Adds the new trigger

            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].GetComponent<DoorState>().doorOpen)
                {
                    // Close the door
                    doors[i].GetComponent<DoorState>().doorOpen = false;
                }
                else
                {
                    // Open the door
                    doors[i].GetComponent<DoorState>().doorOpen = true;
                }
            }

        }
    }
}