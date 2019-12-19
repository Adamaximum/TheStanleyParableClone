using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    DialogueManager manager;

    AudioSource source;
    public AudioClip insaneMusic;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MariellaScene")
        {
            MariellaMusic();
        }
        else
        {
            InsaneMusic();
        }
    }

    void InsaneMusic()
    {
        if (manager.currentLine == 11 && !source.isPlaying)
        {
            source.clip = insaneMusic;
            source.Play();
        }
        if (manager.currentLine == 11)
        {
            source.volume = 0.05f;
        }
        else if (manager.currentLine == 13)
        {
            source.volume = 0.1f;
        }
        else if (manager.currentLine == 15)
        {
            source.volume = 0.15f;
        }
        else if (manager.currentLine == 17)
        {
            source.volume = 0.2f;
        }
        else if (manager.currentLine == 20)
        {
            source.volume = 0.5f;
        }
    }

    void MariellaMusic()
    {
        if (manager.currentLine == 2 && !source.isPlaying)
        {
            source.Play();
        }

        if (manager.currentLine == 2)
        {
            source.volume = 0.4f;
        }
        if (manager.currentLine == 10)
        {
            source.volume = 0.8f;
        }
    }
}
