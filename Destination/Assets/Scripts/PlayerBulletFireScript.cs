using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletFireScript : MonoBehaviour {

    public GameObject bullet;
    public Transform shotSpawn;
    public string fireType;
    public int pooledAmount = 20;
    List<GameObject> bullets;

    private Rigidbody2D rb;
    public float shoot;
    public float fireRate;
    private float nextFire;
    public float fireSpriteLatency;
    public float shotDirection;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireType = PlayerPrefs.GetString("FireType", "turbo");//make this access the options later
        shotDirection = 1;
        Pool();
    }

    void Pool()
    {
        bullets = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            obj.transform.parent = transform;
            bullets.Add(obj);
        }
    }

    // Update is called once per frame
    void Update () {
        GetBulletDir();
        FireBullet();
	}

    void GetBulletDir()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .1)
        {
            shotDirection = Mathf.Sign(Input.GetAxis("Horizontal"));
        }
        //Debug.Log(shotDirection);
    }


    void FireBullet()
    {
        
        
        //shotSpawn.rotation.Set();
        if (fireType == "turbo")
        {
            if (Input.GetAxis("Fire1") != 0.0f && nextFire == 0.0f)
            {
                //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                FireNextBullet(Input.GetAxis("Horizontal"));
                nextFire = fireRate;
            }
            nextFire = Mathf.Max(0.0f, nextFire -= Time.deltaTime);

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }

    void FireNextBullet(float dir)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = Quaternion.Euler(0,0,-90*shotDirection);
               //ullets[i].velocity =
                bullets[i].SetActive(true);
                break;
            }
        }
    }
}
