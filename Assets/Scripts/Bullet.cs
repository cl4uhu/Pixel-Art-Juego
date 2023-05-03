using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody2D;
    GameManager gameManager;

    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
       rBody2D = GetComponent<Rigidbody2D>();

       rBody2D.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse); 

       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
      if(collider.gameObject.layer == 6)
      {
        Enemy enemyScript = collider.gameObject.GetComponent<Enemy>();
        enemyScript.Die();
      }

      if(collider.gameObject.tag == "Purple" || collider.gameObject.tag == "CollisionBlackberries" || collider.gameObject.tag == "Bullet" || collider.gameObject.tag == "CollisionCranberrys")
      {
        Destroy(this.gameObject);
      }

    }
}
