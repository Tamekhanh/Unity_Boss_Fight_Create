using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class script_audio : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject textPrefab;
    public Transform SpamPoint;

    public AudioClip audio;
    private AudioSource audioSource;

    public TextAsset lyric;
    private float lines = 0;
    public float volumeaudio = 0.1f;
    private string[] Data_breakdown;
    public Canvas canvas;
    TextMeshProUGUI[] txt;
    string[] txtbreak;
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
        txtbreak = Data_breakdown[1].Split("");
        for (int i = 0; i < Data_breakdown.Length; i++)
        {

            Instantiate(textPrefab, SpamPoint.position, SpamPoint.rotation);
        }
        
    }

    private void breakdown()
    {
        string[] Data = lyric.text.Split("\n" , System.StringSplitOptions.None);
        Data_breakdown = Data;
    }
}
