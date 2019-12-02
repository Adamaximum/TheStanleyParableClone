using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// USAGE: on an empty GameObject called DialogueManager
// PURPOSE: to receive dialogue and subtitles from triggers, then display/play them on the subtitle canvas
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI centerTitle;

    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public Image panelGiant;

    public Image panelShort;
    public Image panelTall;

    public GameObject currentTrigger;
    public int currentLine;

    public List<string> subtitleTexts;
    public List<AudioClip> voiceOverLines;

    // Start is called before the first frame update
    void Start()
    {
        centerTitle = GameObject.Find("CenterTitle").GetComponent<TextMeshProUGUI>();

        subtitles = GameObject.Find("Subtitles").GetComponent<TextMeshProUGUI>();
        source = GameObject.Find("Subtitles").GetComponent<AudioSource>();

        panelGiant = GameObject.Find("PanelGiant").GetComponent<Image>();

        panelShort = GameObject.Find("PanelShort").GetComponent<Image>();
        panelTall = GameObject.Find("PanelTall").GetComponent<Image>();

        subtitles.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) // Turns off subtitles and panels if no audio is playing
        {
            subtitles.text = "";
            panelGiant.enabled = false;

            panelShort.enabled = false;
            panelTall.enabled = false;
        }
        if (subtitles.text == "")
        {
            panelGiant.enabled = false;
        }

        PlayVoice();
    }

    public void PlayVoice() // Plays through all lines until the list reaches an end
    {
        if (currentLine < voiceOverLines.Count && !source.isPlaying)
        {
            subtitles.text = subtitleTexts[currentLine];
            source.clip = voiceOverLines[currentLine];
            source.Play();

            currentLine++;

            panelGiant.enabled = true;

            //if (subtitles.isTextOverflowing)
            //{
            //    panelTall.enabled = false;
            //    panelShort.enabled = true;
            //}
            //else
            //{
            //    panelTall.enabled = true;
            //    panelShort.enabled = false;
            //}
        }
    }
}
