using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    
    public void Level2Tocado()
    {
        boxCollider.enabled = false; 
        soundManager.StopBGM(); 
        SceneManager.LoadScene(2);
    }

}
