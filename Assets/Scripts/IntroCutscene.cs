using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public SpriteRenderer blackout;

    TextMeshProUGUI centerTitle;
    TextMeshProUGUI clickToSkip;

    public Transform Stanley;
    public GameObject[] stanleyPose;

    public bool fadeIn;
    public int movementPhases;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        blackout = GetComponentInChildren<SpriteRenderer>();

        centerTitle = GameObject.Find("CenterTitle").GetComponent<TextMeshProUGUI>();
        clickToSkip = GameObject.Find("ClickToSkip").GetComponent<TextMeshProUGUI>();

        Stanley = GameObject.Find("Stanley").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentLine == 1)
        {
            clickToSkip.color += new Color (0f, 0f, 0f, 0.005f);
        }
        else if (manager.currentLine == 2)
        {
            clickToSkip.color -= new Color(0f, 0f, 0f, 0.005f);
        }

        if (manager.currentLine == 3)
        {
            movementPhases = 1;
        }

        if (movementPhases == 1)
        {
            stanleyPose[0].SetActive(true);
            stanleyPose[1].SetActive(false);

            transform.position -= new Vector3(0.004f, 0f, 0f);

            blackout.color -= new Color(0, 0, 0, 0.005f);

            if (transform.position.x < 6.8f)
            {
                transform.position = new Vector3(3.19f, 1.054f, 1.92f);
                transform.LookAt(Stanley);
                movementPhases = 2;
            }
        }
        else if (movementPhases == 2)
        {
            stanleyPose[0].SetActive(false);
            stanleyPose[1].SetActive(true);

            transform.position -= new Vector3(0f, 0f, 0.004f);
            transform.LookAt(Stanley);

            if (transform.position.z < -1.7f)
            {
                transform.position = new Vector3(0.426f, 2, -0.153f);
                movementPhases = 3;
            }
        }
        else if (movementPhases == 3)
        {
            stanleyPose[0].SetActive(true);
            stanleyPose[1].SetActive(false);

            transform.position += new Vector3(0.004f, 0f, 0f);
            transform.LookAt(Stanley);

            if (transform.position.x > 3f)
            {
                transform.position = new Vector3(5.841f, 1.1f, 8.1f);
                transform.localEulerAngles = new Vector3(0, -90f, 0);
                movementPhases = 4;
            }
        }
        else if (movementPhases == 4)
        {
            transform.position += new Vector3(0.0005f, 0f, 0f);

            if (transform.position.x > 6.1f)
            {
                blackout.color = new Color(0f, 0f, 0f, 255f);
            }
        }
        else if (movementPhases == 5)
        {
            Stanley.position = new Vector3(-1.253f, transform.position.y, -1.491f);

            stanleyPose[0].SetActive(false);
            stanleyPose[1].SetActive(false);

            blackout.color = new Color(0f, 0f, 0f, 0f);
            transform.position += new Vector3(0.0005f, 0f, 0f);
            transform.LookAt(Stanley);
        }

        if (manager.currentLine == 9)
        {
            centerTitle.color += new Color(0f, 0f, 0f, 0.005f);
        }
        if (manager.currentLine >= 11)
        {
            centerTitle.color -= new Color(0f, 0f, 0f, 0.005f);
        }
        if (manager.currentLine == 11 && movementPhases == 4)
        {
            transform.position = new Vector3(0.55f, 1.054f, -1.242f);
            movementPhases = 5;
        }

        if (manager.currentLine > 15 || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
