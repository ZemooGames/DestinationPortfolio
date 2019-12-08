using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 3.0f;
    static float leftPlayerBoundary = 0.5f;
    static float rightPlayerBoundary = 7.5f;
    static float topPlayerBoundary= -0.5f;
    static float bottomPlayerBoundary = -5.5f;

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

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<Sprite>();
        spRend = GetComponent<SpriteRenderer>();
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

        }else{
            PlayerMovement();
            PlayerVisuals();
        }
    }

    void PlayerMovement()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalSpeed * playerSpeed, verticalSpeed * playerSpeed, 0.0f);
        rb.velocity = movement;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, leftPlayerBoundary, rightPlayerBoundary),
            Mathf.Clamp(rb.position.y, bottomPlayerBoundary, topPlayerBoundary),
            0.0f
            );
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
        Debug.Log("trigger");
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
