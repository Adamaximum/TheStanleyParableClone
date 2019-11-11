using System.Collections;
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
            SpecialEventTriggers();
        }
    }

    void SpecialEventTriggers()
    {
        if (gameObject.tag == "TriggerLounge")
        {
            doors[0].GetComponent<DoorState>().doorOpen = false;

            if (manager.currentLine == subtitleTexts.Length && !manager.source.isPlaying)
            {
                doors[1].GetComponent<DoorState>().doorOpen = true;
            }
        }
        if (gameObject.tag == "TriggerInsane")
        {
            doors[0].GetComponent<DoorState>().doorOpen = false;

            if (manager.currentLine > 14)
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].GetComponent<DoorState>().doorOpen = false;
                }
            }
            if (manager.currentLine > 20)
            {
                Camera.main.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !triggered)
        {
            triggered = true; // Ensures this trigger won't start again

            if (subtitleTexts.Length > 0 && voiceOverLines.Length > 0) // Only if there is dialogue
            {
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
            }

            if (gameObject.tag == "TriggerNormal" || gameObject.tag == "TriggerRepeating")
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].GetComponent<DoorState>().doorOpen = !doors[i].GetComponent<DoorState>().doorOpen;
                }
            }
        }
    }
}
