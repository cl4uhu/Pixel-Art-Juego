using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // velocidad Purple
    public float playerSpeed = 5f;
    // salto Purple
    public float jumpForce = 7f;
    // texto consola
    string texto = "Welcome back Purple";
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
     //variable para almacenar el input de movimiento
    float horizontal;
    //variable para acceder al Animator
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rBody= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            //anim.SetBool("IsRunning", true);
        }

        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
            //anim.SetBool("IsRunning", true);
        }

        else
        {
            //anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //anim.SetBool("IsJumping", true);
        }
    }
        void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
    }

