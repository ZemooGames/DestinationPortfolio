using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtFireScript : MonoBehaviour
{
    // public GameObject bullet;
    public GameObject BossRed;
    public GameObject BossBlue;
    public GameObject BossYellow;
    public GameObject BossPurple;
    public GameObject BossGrey;
    public GameObject BackgroundHolder;
    public BackgroundController bgController;
    public GameObject activeBoss;
    public Transform shotSpawn;
    public GameObject bullet;
    //public Transform shotSpawn;
    public int pooledAmount = 20;
    //List<GameObject> bullets;
    public GameObject bulletObject;
    //this is set in inspector as a prefab
    List<Bullet> bullets;

    private Rigidbody2D rb;
    public float shoot;
    public float fireRate;
    private float nextFire;
    public float fireSpriteLatency;
    public int poolPointer = 0;

    public struct Bullet
    {
        public int id;
        public GameObject obj;
        public Rigidbody2D rb;
        public Animator anim;
        //public string tag;
        //struct Bullet* next;

        public Bullet(int identifier, GameObject gObject)
        {
            this.id = identifier;
            this.obj = gObject;
            //gObject.tag = BossHurtFireScript.bulletColor   
            //this.tag = "";//GetActiveBoss();
            //gObject.tag = "R"
            //change tag
            this.obj.SetActive(false);
            this.rb = obj.GetComponent<Rigidbody2D>();
            this.anim = obj.GetComponent<Animator>();
            //obj.GetComponentInChildren<SpriteRenderer>();
            // bullet.anim = obj.GetComponent<Animator>();//TODO fix
            // bullet.anim = obj.GetComponent<Texture>().GetComponent<Animator>();//TODO fix
            //bullet.anim = obj.GetComponent<Texture2D>().GetComponent<Animator>();//TODO fix
            this.SetRotation(0.0f);

        }

        public int GetID()
        {
            return this.id;
        }
        public GameObject GetObj()
        {
            return this.obj;
        }
        public Rigidbody2D GetRB()
        {
            return this.rb;
        }
        public Animator GetAnim()
        {
            return this.anim;
        }
        public float GetXSpeed()
        {
            return GetRB().velocity.x;
        }
        public float GetYSpeed()
        {
            return GetRB().velocity.y;
        }
        public Vector2 GetVelocity()
        {
            return new Vector2(GetXSpeed(), GetYSpeed());
        }
        public float GetRotation()
        {
            return GetRB().rotation;
        }
        public void SetRotation(float newRotation)
        {
            this.GetRB().rotation = newRotation;
        }
        public Vector2 GetPosition()
        {
            return this.GetObj().transform.position;
        }
    };

    public enum bulletColor
    {
        red,
        blue,
        yellow,
        purple,
        grey
    }

    public bulletColor GetEnumColor(string color)
    {
        switch (color)
        {
            case "red":
                return bulletColor.red;
            case "blue":
                return bulletColor.blue;
            case "purple":
                return bulletColor.purple;
            case "yellow":
                return bulletColor.yellow;
            default:
                return bulletColor.grey;
        }

    }

    // Use this for initialization
    void Start()
    {
        bullets = new List<Bullet>();
        for (int i = 0; i < 1; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletObject);
            Bullet bullet = new Bullet(i, obj);
            bullets.Add(bullet);
            
        }
    }

    void Pool()
    {
        bullets = new List<Bullet>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            obj.transform.parent = transform;
            //obj.tag = "BossKiller";
            //bullets.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GetBulletDir();
        //FireBullet();
    }

    void GetBulletDir()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .1)
        {

        }
        //Debug.Log(shotDirection);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PlayerBullet")
        {
            Vector2 pos = new Vector2(3f, -5f);
            //Quaternion q = new Quaternion.Euler(0, 0, 0);
            pos = shotSpawn.transform.position;
            
            //Vector2(shotSpawn.TransformVector)
            float angle = GetAngle(shotSpawn.transform.position, GetActiveBoss().transform.position);
            //Debug.Log("Spike Trigger " +activeBoss + "  " + angle);
            CreateShot(pos, angle, 1f, GetEnumColor(bgController.GetColor()));
            //CreateShot(pos, angle, 1f, BackgroundHolder.BgColor);
        }

    }

    public GameObject GetActiveBoss()
    {
        switch (bgController.GetColor())
        {
            case "red":
                return BossRed;
            case "blue":
                return BossBlue;
            case "purple":
                return BossPurple;
            case "yellow":
                return BossYellow;
            default:
                return BossGrey;
        }
    }

    void FireBullet()
    {
        //shotSpawn.rotation.Set(); 
        //FireNextBullet(Input.GetAxis("Horizontal"));

    }
    /*
        void FireNextBullet(float dir)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    if (activeBoss != null)
                    {
                        bullets[i].transform.parent = activeBoss.transform;
                    }
                    bullets[i].transform.position = shotSpawn.position;
                    bullets[i].transform.rotation = Quaternion.Euler(180, 0, 0);
                    //ullets[i].velocity =
                    bullets[i].SetActive(true);
                    break;
                }
            }
        }*/

    public bool MovePointer()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            poolPointer++;
            if (poolPointer == bullets.Count)
            {
                poolPointer = 0;
            }
            if (!bullets[poolPointer].obj.activeInHierarchy)
            {
                Debug.Log(poolPointer);
                return true;
            }
        }
        //Debug.Log("<color=#ff0000ff>Pool's Closed</color>");
        return false;
    }

    public int CreateShot(Vector2 startPosition, float rotation, float speed, bulletColor color)
    {
        if (MovePointer())
        {
            Bullet newShot = GetBullet(poolPointer);

            newShot.obj.SetActive(true);
            newShot.obj.transform.position = startPosition;
            SetVelocity(newShot.id, rotation, speed);
            SetColor(bullets[newShot.id], color);
            return newShot.id;
        }
        return -1;
    }

    public Bullet GetBullet(int id)
    {
        return bullets[id];
    }
    public int GetID(Bullet shot)
    {
        return shot.id;
    }

    public void SetColor(Bullet shot, bulletColor color)
    {

        shot.anim.SetTrigger(color.ToString());
        shot.GetObj().tag = color.ToString();
    }

    public void SetVelocity(int id, float angle, float speed)
    {
        //Bullet shot = GetBullet(id);
        Bullet shot = bullets[id];
        //Debug.Log("OLD x " + shot.xSpeed + " Old y " + shot.ySpeed);
        float xSpeed = Mathf.Cos(GetRadians(angle)) * speed + 0.0f;
        //bullets[id].SetXSpeed(1.0f);
        //.xSpeed = shot.xSpeed;
        float ySpeed = Mathf.Sin(GetRadians(angle)) * speed + 0.0f;
        //Debug.Log("d " + new Vector2(xSpeed, ySpeed) + " ANGLE " + angle + " New xSPeed " + xSpeed + " new yspeed " + ySpeed);
        //shot.rb.velocity = new Vector2(shot.xSpeed * 1.000000f,shot.ySpeed* 1.000000f ).normalized * speed;
        shot.rb.velocity = Vector2.right * xSpeed + Vector2.up * ySpeed;
    }
    public float GetRadians(float F)
    {
        // Debug.Log("input " + F + " Output " + F * 180 / (2 * Mathf.PI));
        return F / 180 * Mathf.PI;
    }

    public float GetAngle(Vector2 point1, Vector2 point2)
    // Given two points returns the angle in Radians between them
    {
        float x1 = point1.x;
        float y1 = point1.y;
        float x2 = point2.x;
        float y2 = point2.y;
        float xDelta = x2 - x1;
        float yDelta = y2 - y1;
        //signs might be wrong?
        return Mathf.Atan2(yDelta, xDelta) * Mathf.Rad2Deg;
        // Debug.Log("" +xDelta + "   /   " + yDelta + " || " + Mathf.Tan(yDelta / xDelta) + " Need to figure out how to not divide by zero here");

    }
}
