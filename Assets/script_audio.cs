using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class script_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audio;
    private AudioSource audioSource;
    public TextAsset lyric;
    private float lines = 0;
    public float volumeaudio = 0.1f;
    private string[] Data_breakdown;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.volume = volumeaudio;
        audioSource.enabled = true;
        audioSource.Play();
        breakdown();

    }

    private void Update()
    {

        Debug.Log(Data_breakdown[1]);
    }

    private void breakdown()
    {
        string[] Data = lyric.text.Split("\n" , System.StringSplitOptions.None);
        Data_breakdown = Data;
    }
}
