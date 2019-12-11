using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ApartmentCutscene : MonoBehaviour
{
    public DialogueManager manager;
    public TextMeshProUGUI centerTitle;

    public PlayerMoveScript controls;
    public MouseLook mouseLook;
    public SpriteRenderer fade;

    public int currentText;
    public string[] centerText;

    bool displayCredits;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        centerTitle = GameObject.Find("CenterTitle").GetComponent<TextMeshProUGUI>();

        controls = GameObject.Find("Player").GetComponent<PlayerMoveScript>();
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        fade = GameObject.Find("Camera Filter").GetComponent<SpriteRenderer>();

        StartCoroutine(TextDisplay());
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentLine < 16)
        {
            fade.color -= new Color(0, 0, 0, 0.005f);
        }
        else if (manager.currentLine == 16 && displayCredits == false)
        {
            fade.color = new Color(0, 0, 0, 255);
            controls.enabled = false;
            mouseLook.enabled = false;
            
            StartCoroutine(CreditsDisplay());
            displayCredits = true;
        }
    }

    IEnumerator TextDisplay()
    {
        Debug.Log("Coroutine has started...");

        centerTitle.text = "";

        if (currentText == 5)
        {
            yield return new WaitForSeconds(9);
        }
        else
        {
            yield return new WaitForSeconds(2);
        }

        centerTitle.text = centerText[currentText];

        if (currentText == 12)
        {
            yield return new WaitForSeconds(10);
        }
        else
        {
            yield return new WaitForSeconds(5);
        }
        
        currentText++;

        if (currentText < centerText.Length)
        {
            StartCoroutine(TextDisplay());
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
