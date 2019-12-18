using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// USAGE: on EventTrigger objects
// PURPOSE: to trigger scripted events on collision, such as dialogue and subtitles, doors, etc.
public class EventTrigger : MonoBehaviour
{
    public DialogueManager manager;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;
    public DoorState[] doors;

    elevatorScript elevator;
    public ElevatorDoor[] elevatorDoors;

    public bool triggered;
    
    [Header ("Player Effects")]
    public PlayerMoveScript controls;
    public MouseLook mouseLook;
    public SpriteRenderer filter;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        if (gameObject.tag == "TriggerElevator")
        {
            elevator = GameObject.Find("Elevator").GetComponent<elevatorScript>();
        }

        controls = GameObject.Find("Player").GetComponent<PlayerMoveScript>();
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        filter = GameObject.Find("Camera Filter").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered) // Activates the Dialogue Manager and Special Events (if applicable)
        {
            manager.PlayVoice(); // Gets the manager to play the audio and display the subtitles
            SpecialEventTriggers(); // Activates special events (if applicable)
        }
    }

    void SpecialEventTriggers()
    {
        if (gameObject.tag == "TriggerLounge") // The second door in the lounge opens after a delay
        {
            doors[0].doorOpen = false;

            if (doors[0].doorOpen == false)
            {
                doors[0].doorMoving = false;
            }

            if (manager.currentLine == subtitleTexts.Length && !manager.source.isPlaying)
            {
                doors[1].doorOpen = true;
                doors[1].doorMoving = false;
            }
        }

        if (gameObject.tag == "TriggerInsane") // Triggers scripted events after a certain amount of lines
        {
            doors[0].doorOpen = false;

            if (doors[0].doorOpen == false)
            {
                doors[0].doorMoving = false;
            }

            if (manager.currentLine > 14) // All doors close past this line
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].doorOpen = false;

                    if (doors[i].doorOpen == false)
                    {
                        doors[i].doorMoving = false;
                    }
                }

                if (filter.color.a < 190) // Red filter begins fading in
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

        if (gameObject.tag == "TriggerRedDoor") // Blacks out the camera after a delay, then transitions
        {
            doors[0].doorOpen = false;

            if (doors[0].doorOpen == false)
            {
                doors[0].doorMoving = false;
                StartCoroutine(BlackoutDelay());
                Debug.Log("Red is closed!");
            }

            if (manager.currentLine == 3) // Fades in the title card
            {
                manager.centerTitle.color += new Color(0, 0, 0, 0.008f);
            }
            if (manager.currentLine == 4 && !manager.source.isPlaying) // Fades out
            {
                manager.centerTitle.color -= new Color(0, 0, 0, 0.008f);

                if (manager.centerTitle.color.a <= 0)
                {
                    SceneManager.LoadScene("ApartmentEnding");
                }
            }
        }

        if (gameObject.tag == "TriggerElevator") // Moves the elevator and times opening of the doors
        {
            if (manager.currentLine == 3 && subtitleTexts.Length == 4) // The first trigger moves the elevator up
            {
                elevator.movingUp = true;
            }

            if (manager.currentLine == subtitleTexts.Length && !manager.source.isPlaying) // Opens doors at end of second trigger lines
            {
                for (int i = 0; i < elevatorDoors.Length; i++)
                {
                    elevatorDoors[i].doorOpen = !elevatorDoors[i].doorOpen;
                }
                Destroy(this.gameObject); // Destroy the object immediately to prevent it from causing more trouble
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

            if (gameObject.tag == "TriggerNormal" || gameObject.tag == "TriggerRightDoor" || gameObject.tag == "TriggerElevator")
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].doorOpen = !doors[i].doorOpen;
                    doors[i].doorMoving = false;
                }
            }

            if (gameObject.tag == "TriggerRepeating") // First door always closes, second always opens
            {
                doors[0].doorOpen = false;
                doors[1].doorOpen = true;

                doors[0].doorMoving = false;
                doors[1].doorMoving = false;
            }
        }
    }

    IEnumerator BlackoutDelay()
    {
        yield return new WaitForSeconds(2);

        filter.color = new Color(0, 0, 0, 255);
        controls.enabled = false;
        mouseLook.enabled = false;
    }
}
