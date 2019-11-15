using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTrigger : MonoBehaviour
{
    public DialogueManager manager;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;
    public DoorState[] doors;

    public bool triggered;
    
    public PlayerMoveScript controls;
    public MouseLook mouseLook;
    public SpriteRenderer filter;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        
        controls = GameObject.Find("Player").GetComponent<PlayerMoveScript>();
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        filter = GameObject.Find("Camera Filter").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered) // Activates the Dialogue Manager and Special Events (if applicable)
        {
            manager.PlayVoice();
            SpecialEventTriggers();
        }
    }

    void SpecialEventTriggers()
    {
        if (gameObject.tag == "TriggerLounge") // The second door in the lounge opens after a delay
        {
            doors[0].doorOpen = false;

            if (manager.currentLine == subtitleTexts.Length && !manager.source.isPlaying)
            {
                doors[1].doorOpen = true;
            }
        }
        if (gameObject.tag == "TriggerInsane") // Triggers scripted events after a certain amount of lines
        {
            doors[0].doorOpen = false;

            if (manager.currentLine > 14) // All doors close past this line
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].doorOpen = false;
                }

                if (filter.color.a < 190)
                {
                    filter.color += new Color(0, 0, 0, 0.00035f);
                }
            }
            if (manager.currentLine > 19) // Camera goes black then transitions at end of lines
            {
                filter.color = new Color(0, 0, 0, 255);
                controls.enabled = false;
                mouseLook.enabled = false;

                if (!manager.source.isPlaying)
                {
                    SceneManager.LoadScene("MariellaScene");
                }
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

            if (gameObject.tag == "TriggerNormal")
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].doorOpen = !doors[i].doorOpen;
                }
            }
            if (gameObject.tag == "TriggerRepeating")
            {
                doors[0].doorOpen = false;
                doors[1].doorOpen = true;
            }
        }
    }
}
