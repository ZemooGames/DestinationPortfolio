using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 3.0f;
    public float playerFocusSpeed = 1.5f;
    private Vector3 movement;
    static float leftPlayerBoundary = 0.41f;
    static float rightPlayerBoundary = 7.59f;
    static float topPlayerBoundary= -0.390f;
    static float bottomPlayerBoundary = -5.59f;

    public GameObject shot;
    public Transform shotSpawn;
    public string fireType;
    
    private Rigidbody2D rb;
    public Animator anim;
    public Sprite sprite;
    public SpriteRenderer spRend;
    public float shoot;
    public float fireRate;
    private float nextFire;
    public float fireSpriteLatency;
    public int lives;
    public bool invincible;
    private bool gameOver;
    public Vector3 startPosition;
    //private Color spritecolor;
    //private 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<Sprite>();
        spRend = GetComponent<SpriteRenderer>();
        //spritecolor = spRend.color;
        fireType = PlayerPrefs.GetString("FireType","turbo");//make this access the options later
        lives = PlayerPrefs.GetInt("StartingLives", 3);//make this accessable later
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        //FireBullet();

    }


    void FixedUpdate()
    {
        if (gameOver)
        {
            rb.velocity = new Vector3(0.0f,0.0f,0.0f);
        }else{
            PlayerMovement();
            PlayerVisuals();
        }
    }

    void PlayerMovement()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        if (Input.GetAxis("Fire2") > 0.5f)//Focus Movement
        {
            movement = new Vector3(horizontalSpeed * playerFocusSpeed, verticalSpeed * playerFocusSpeed, 0.0f);
        }
        else
        {
            movement = new Vector3(horizontalSpeed * playerSpeed, verticalSpeed * playerSpeed, 0.0f);
        }
        
        if (rb.position.x < leftPlayerBoundary)
        {
            movement.x = Mathf.Max(movement.x, 0);
        }else if(rb.position.x > rightPlayerBoundary)
        {
            movement.x = Mathf.Min(movement.x, 0);
        }
        if (rb.position.y < bottomPlayerBoundary)
        {
            movement.y = Mathf.Max(movement.y, 0);
        }
        else if (rb.position.y > topPlayerBoundary)
        {
            movement.y = Mathf.Min(movement.y, 0);
        }

        rb.velocity = movement;

       /* 
        * //More elegant looking code, but player slides back off the wall
        *
         rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, leftPlayerBoundary, rightPlayerBoundary),
            Mathf.Clamp(rb.position.y, bottomPlayerBoundary, topPlayerBoundary),
            0.0f
            );*/
    }

    void FireBullet()
    {
        if (fireType == "turbo")
        {
            if (Input.GetAxis("Fire1") != 0.0f && nextFire == 0.0f)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                nextFire = fireRate;
            }
            nextFire = Mathf.Max(0.0f,nextFire -= Time.deltaTime);

        }else{
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }

    void PlayerVisuals()
    {
        /*float shoot = ;
        string s = shoot.ToString();
        Debug.Log(s);
        */
        //STILLNEEDTODOTHIS with fireSpriteLatency
        if (fireType == "turbo")
        {
            if (Input.GetAxis("Fire1") != 0.0f)//fireRate)
            {
                //anim.SetBool("Shoot", true);
                //don't want this animation anymore
            }
            else
            {
                anim.SetBool("Shoot", false);
            }
        }
        else
        {
           if (Input.GetAxis("Fire1") != 0.0f)
            {
                //anim.SetBool("Shoot", true);
                //don't want this anymore TODO remove
            }
            else
            {
                anim.SetBool("Shoot", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Player collide with other");
            if (other.tag == "PlayerKiller")
            {
                if (!invincible)
                {
                    PlayerDeath();
                }
            }

    }

    void PlayerDeath()
    {
        lives--;
        Debug.Log(lives + "   &");
        if (lives < 1)
        {
            gameOver = true;
            //gameover
            //Controller.ResetScene();
        }
        enableInvincibility();
        Invoke("disableInvincibility", 5);
        return;
    }


    void disableInvincibility()
    {
        invincible = false;
    }
    void enableInvincibility()
    {
        invincible = true;
    } 

    public bool IsGameOver()
    {
        return gameOver;
    }
}
