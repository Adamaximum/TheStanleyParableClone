using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (manager.currentLine > 2 && manager.source.isPlaying)
        {
            fade.color -= new Color(0, 0, 0, 0.005f);

            transform.localPosition += new Vector3(0, 0.002f, 0);
        }
        else
        {
            fade.color = new Color(0, 0, 0, 255);
        }
    }
}
