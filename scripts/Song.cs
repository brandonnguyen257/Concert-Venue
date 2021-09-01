﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Song
{

    public string number;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

}
