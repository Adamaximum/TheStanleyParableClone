using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// USAGE: on an empty GameObject called DialogueManager
// PURPOSE: to receive dialogue and subtitles from triggers, then display/play them on the subtitle canvas
public class DialogueManager : MonoBehaviour
{
    public Canvas subCanvas;

    public TextMeshProUGUI centerTitle;

    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public Image panel;

    public GameObject currentTrigger;
    public int currentLine;

    public List<string> subtitleTexts;
    public List<AudioClip> voiceOverLines;

    // Start is called before the first frame update
    void Start()
    {
        subCanvas = GameObject.Find("SubtitleCanvas").GetComponent<Canvas>();

        centerTitle = GameObject.Find("CenterTitle").GetComponent<TextMeshProUGUI>();

        subtitles = GameObject.Find("Subtitles").GetComponent<TextMeshProUGUI>();
        source = GameObject.Find("Subtitles").GetComponent<AudioSource>();

        panel = GameObject.Find("Panel").GetComponent<Image>();

        subtitles.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) // Turns off subtitles and panel if no audio is playing
        {
            subtitles.text = "";
            panel.enabled = false;
        }
        if (subtitles.text == "") // Turns off the panel if there are no subtitles
        {
            panel.enabled = false;
        }

        PlayVoice();
    }

    public void PlayVoice() // Plays through all lines until the list reaches an end
    {
        if (currentLine < voiceOverLines.Count && !source.isPlaying)
        {
            subtitles.text = subtitleTexts[currentLine]; // Subtitle is the current subtitle on the list

            // Adjusts panel length to fit with text
            subtitles.ForceMeshUpdate();
            Vector2 subSize = subtitles.textBounds.size;
            subSize.x = panel.rectTransform.sizeDelta.x;
            panel.enabled = true;
            subSize += new Vector2(0f, 1f);
            panel.rectTransform.sizeDelta = subSize;

            source.clip = voiceOverLines[currentLine]; // Audio is the current audio on the list
            source.Play(); // Plays the audio

            currentLine++; // Iterates the current line
        }
    }
}
