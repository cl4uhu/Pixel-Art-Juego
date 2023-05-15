using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{
    public AudioClip lvl2Music;

    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>(); 

        source.clip = lvl2Music;
        source.Play();
    }

    public void StopBGM()
    {
        source.Stop();
    }
}