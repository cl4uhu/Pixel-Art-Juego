using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip cranberrysstock;
    public AudioClip blackberriesstock;

    private AudioSource source;
    
    // Start is called before the first frame update
   
    void Awake()
    {
       source = GetComponent<AudioSource>(); 
    }

     public void CranberryStock()
    {
        source.PlayOneShot(cranberrysstock);
    }

     public void BlackberrieStock()
    {
        source.PlayOneShot(blackberriesstock);
    }

}
