using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranberrysManager : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    public void DestruccionCranberrys()
    {
        boxCollider.enabled = false; 
        Destroy(this.gameObject);
        sfxManager.CranberrysManager();
    }
}
