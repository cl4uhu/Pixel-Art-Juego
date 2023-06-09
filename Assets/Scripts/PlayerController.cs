using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // velocidad Purple
    public float playerSpeed = 5f;
    // salto Purple
    public float jumpForce = 8f;
    // texto consola
    string texto = "Welcome back Purple";
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
     //variable para almacenar el input de movimiento
    float horizontal;
    //variable para acceder al Animator
    public Animator anim;
    public BlackberriesManager blackberriesmanager;
    public CranberrysManager cranberrysmanager;
    public HoneyManager honeymanager;
    GameManager gameManager;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Level2Manager level2Manager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rBody= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        Debug.Log("Welcome back Purple");
        blackberriesmanager = GameObject.Find("BlackberriesManager").GetComponent<BlackberriesManager>();
        cranberrysmanager = GameObject.Find("CranberrysManager").GetComponent<CranberrysManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        }

        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        }

        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            
        }
    }
        void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionBlackberries") 
        {
            BlackberriesManager blackberriesmanager = collision.gameObject.GetComponent<BlackberriesManager>();
            blackberriesmanager.DestruccionBlackberries();
        }

        if (collision.gameObject.tag == "CollisionCranberrys") 
        {
            CranberrysManager cranberrysmanager = collision.gameObject.GetComponent<CranberrysManager>();
            cranberrysmanager.DestruccionCranberrys();
        }

        if (collision.gameObject.tag == "CollisionHoney") 
        {
            HoneyManager honeymanager = collision.gameObject.GetComponent<HoneyManager>();
            honeymanager.DestruccionHoney();
        }

        if (collision.gameObject.tag == "Level2Collision") 
        {
            Level2Manager level2Manager = collision.gameObject.GetComponent<Level2Manager>();
            level2Manager.Level2Tocado();
        }
    }
    
    }

