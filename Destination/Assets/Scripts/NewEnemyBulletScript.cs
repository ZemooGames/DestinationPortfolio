using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBulletScript : QuickMaths
{
    public struct Bullet
    {
        public int id;
        public GameObject obj;
        public Rigidbody2D rb;
        public Animator anim;
        public CircleCollider2D collide;
        public bool graze;
        public bool bound;
        //struct Bullet* next;

        public Bullet(int identifier, GameObject gObject)
        {
            this.id = identifier;
            this.obj = gObject;
            gObject.tag = "PlayerKiller";
            this.obj.SetActive(false);
            this.rb = obj.GetComponent<Rigidbody2D>();
            this.anim = obj.GetComponentInChildren<Animator>();
            this.collide = obj.GetComponent<CircleCollider2D>();// maybe temp IDK
            obj.GetComponentInChildren<SpriteRenderer>();
            // bullet.anim = obj.GetComponent<Animator>();//TODO fix
            // bullet.anim = obj.GetComponent<Texture>().GetComponent<Animator>();//TODO fix
            //bullet.anim = obj.GetComponent<Texture2D>().GetComponent<Animator>();//TODO fix
            this.graze = false;
            this.bound = false;
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
        /*
        public GameObject GetObj(int id)
        {
            bullets[id].SetTag("bound");
        }*/
        public Rigidbody2D GetRB()
        {
            return this.rb;
        }
        public Animator GetAnim()
        {
            return this.anim;
        }
        public bool GetGraze()
        {
            return this.graze;
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
        public void SetGraze()
        {
            this.graze = true;
        }
        public void SetRotation(float newRotation)
        {
            this.GetRB().rotation = newRotation;
        }
        public Vector2 GetPosition()
        {
            return this.GetObj().transform.position;
        }
        public void SetBound(bool val)
        {
            this.bound = val;
        }
        public bool GetBound()
        {
            return this.bound;
        }

        /*public Bullet GetThis(CircleCollider2D collider)
        {
            collider.
        }*/
    };

    public enum bulletColor
    {
        red,
        blue,
        yellow,
        purple,
        teal,
        chartruse
    }

    public GameObject bulletObject;
    //this is set in inspector as a prefab
    List<Bullet> bullets;
    //List<bulletColor> bulletColors;
    //maybe bulletFireScript should handle this list, would be more generic here
    public int poolStartSize;
    public int poolPointer = 0;
    private float rot = 90.0f; //temp
    // private string[] colors = { "grey", "red", "blue", "purple", "yellow" };

    private void Start()
    {
        bullets = new List<Bullet>();
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletObject);
            Bullet bullet = new Bullet(i, obj);
            bullets.Add(bullet);

        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
            //the space bar isn't part of the game, just a dev tool for me right now
        {
            Vector2 vect = new Vector2(4, -4);
            Vector2 vect2 = new Vector2(6, -4);
            Vector2 vect3 = new Vector2(4, -6);
            Vector2 vect4 = new Vector2(2, -4);
            Vector2 vect5 = new Vector2(2, -2);
            Vector2 vect6 = new Vector2(2, -6);
            Vector2 vectRegular = new Vector2(7, 0);
            float sp = 3.0f;
            //CreateShot(vect, 185.0f, sp, bulletColor.blue);
            CreateBoundShot(vect, 35, 5, bulletColor.yellow);
            ChangeDestAtSpeed(3, 4, 4, 10);
            //for (int i = 0; i < 6; i++) { 
                rot += 45.0f;
            //  CreateShot(vect, rot, sp, (bulletColor)Mathf.RoundToInt(Random.Range(0.0f, 6.0f)));
            // CreateShot(vect, rot, sp, (bulletColor)Mathf.RoundToInt(Random.Range(0.0f, 6.0f)));
            //CreateShotAtFrame(vect2, vect, 60, bulletColor.purple);
            //CreateShotAtFrame(vect3, vect, 60, bulletColor.purple);
            //CreateShotAtFrame(vect4, vect, 60, bulletColor.purple);
            //CreateShotAtFrame(vect5, vect, 60, bulletColor.purple);
            //CreateShotAtFrame(vect6, vect, 60, bulletColor.purple);
            //CreateShotAtFrame(vectRegular, vect, 60, bulletColor.purple);

            //}
            // FireNextBullet(vect);
        }*/
        if (Input.GetKeyDown(KeyCode.A))
        {
                SetColor(bullets[3], bulletColor.chartruse);
            for (int i = 0; i < bullets.Count; i++) {
                Vector2 foo = new Vector2(7.0f,-5.0f);
                ChangeDestAtFrame(i, foo, 5);
                //ChangeDestAtSpeed(i, 4.000f, -4.000f, 1.500000f);

            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                Bullet s = bullets[i];
                Debug.Log("ID: " + s.GetID() +"," + bullets[i].GetID() + "\n" + "GameObject: "+ s.obj + "\n" + "Rigid Body: " + s.rb + "\n" + "Xspeed: " + s.GetXSpeed() + "\n" + "Yspeed: " + s.GetYSpeed() + "\n" + "Rotation: " + s.GetRotation());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        //this isn't working yet
    {
        //this.GetID();
        Debug.Log("Bullet ONTRIGGER " + this.gameObject.ToString());
        //this.bulletObject.GetID
        if (collision.CompareTag("bound"))
        {

            //SetVelocity(this.GetID, rotation, speed);
        }
    }

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
                //Debug.Log(poolPointer);
                return true;
            }
        }
        //Debug.Log("<color=#ff0000ff>Object pool full</color>");
        return false;
    }
    public Bullet GetNextBullet()
    {
        for (int i = 1; i < bullets.Count; i++)
        {
            if (!bullets[i].obj.activeInHierarchy)
            {
                return bullets[i];
            }
        }
        Debug.Log("GetNextBullet could not find available bullet");
        return bullets[0];//fix this later
    }
    public int GetNextBulletID()
    {
        for (int i = 1; i < bullets.Count; i++)
        {
            if (!bullets[i].obj.activeInHierarchy)
            {
                return i;
            }
        }
        Debug.Log("GetNextBullet could not find available bullet");
        return 0;//fix this later
    }

    public int CreateShot(Vector2 startPosition, float rotation, float speed, bulletColor color)
    {
        if (MovePointer())
        {
            Bullet newShot = GetBullet(poolPointer);

            newShot.obj.SetActive(true);
            newShot.obj.transform.position = startPosition;

          
            SetVelocity(newShot.id, rotation, speed/2);

            SetColor(bullets[newShot.id], color);

            return newShot.id;
        }
        return -1;
    }

    public int CreateShotAtFrame(Vector2 startPosition, Vector2 destination, int frame, bulletColor color)
    {
        if (MovePointer())
        {
            Bullet newShot = new Bullet();
            newShot.id = poolPointer;

            newShot.obj = bullets[newShot.id].obj;
            newShot.rb = bullets[newShot.id].rb;
            newShot.obj.SetActive(true);
            newShot.obj.transform.position = startPosition;
            float rotation = GetAngle(startPosition, destination);
            float distance = GetDistance(startPosition, destination);
            SetVelocity(newShot.id, rotation, 10 * distance / frame);
            return newShot.id;
        }
        return -1;
    }

    public int CreateBoundShot(Vector2 startPosition, float rotation, float speed, bulletColor color)
    {
        if (MovePointer())
        {
            Bullet newShot = GetBullet(poolPointer);
            newShot.obj.SetActive(true);
            newShot.SetBound(true);
            newShot.obj.transform.position = startPosition;
            SetVelocity(newShot.id, rotation, speed);
            SetColor(bullets[newShot.id], color);
            return newShot.id;
        }
        return -1;
    }

    public int CreateBounceShot(Vector2 startPosition, float rotation, float speed, bulletColor color)
    {
        int ret = CreateShot(startPosition, rotation, speed, color);
        //Bullet shot = GetBullet(ret);
        //.SetTag("bound");
        return ret;
    }


    public void SetColor(Bullet shot, bulletColor color)
    {
        shot.anim.SetTrigger(color.ToString());
        //shot.anim.SetInteger("CherryColor", 3);
        //shot.anim.SetInteger("CherryColor", bulletColor.color);
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
            case "teal":
                return bulletColor.teal;
            case "chartruse":
                return bulletColor.chartruse;
            default:
                return bulletColor.red;
        }
            
    }

    public void SetVelocity(int id, float angle, float speed)
    {
        Bullet shot = bullets[id];
        float xSpeed = Mathf.Cos(GetRadians(angle)) * speed + 0.0f;
        float ySpeed = Mathf.Sin(GetRadians(angle)) * speed + 0.0f;
        shot.rb.velocity = Vector2.right * xSpeed + Vector2.up * ySpeed;
    }

    public void SetScale(int id, float scale)
    {
        Bullet shot = GetBullet(id);
        Rigidbody2D rb = shot.GetRB();
        Vector2 temp = new Vector2(scale, scale);
        //temp.x = HP / MaxHP;
        //temp.
        Debug.Log("Scale " +scale);

        //tempF;
        rb.transform.localScale = temp;

    }

    public void ChangeDestAtSpeed(int id,float destX, float destY, float frame)
    {
        Bullet shot = GetBullet(id);
        Vector3 shotPosition = shot.obj.transform.position;
        float xDelta = destX - shotPosition.x;
        float yDelta = destY - shotPosition.y;
        Vector2 temp = Vector2.right * xDelta + Vector2.up * yDelta;
        shot.rb.velocity = temp.normalized;
    }

    public void ChangeDestAtFrame(int id, Vector2 destination, int frame)
    {

        if (bullets[id].GetObj().activeInHierarchy)
        {
            Vector2 startPosition = bullets[id].GetPosition();
            float rotation = GetAngle(startPosition, destination);
            float distance = GetDistance(startPosition, destination);
            SetVelocity(id, rotation, 10 * distance / frame);
        }
        
    }

    public Bullet GetBullet(int id)
    {
        return bullets[id];
    }
    public int GetID(Bullet shot)
    {
        return shot.id;
    }

    public void SetTag(string newTag)
    {
        this.tag = newTag;
    }
}
