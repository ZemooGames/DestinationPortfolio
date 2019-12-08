using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : NewEnemyBulletScript {
    //the bounce functionality is currently not ready

    //public NewEnemyBulletScript shooter = new NewEnemyBulletScript();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
        //Must be Collider2D
    {
        //get other velocity and reverse it
        //Bullet b = other.GetComponent<Bullet>();
        //string b = ;
       //other.SetVelocity(int id, float angle, float speed)
        //if ()
        if (other.gameObject.name.ToString() == "AppleBullet(Clone)")
        {
            //Bullet bul = (Bullet)other.gameObject;
            //Rigidbody2D rbO = other.GetComponent<Rigidbody2D>();
            Rigidbody2D rbT = this.GetComponent<Rigidbody2D>();
            Vector2 v = rbT.velocity;
            rbT.velocity = Vector2.right * -v.x + Vector2.up * -v.y;
            
            //rb.GetPointVelocity(rb.transform())
            Debug.Log("This should bounce" + v +" Other tag " + other.tag +" RB transform " + rbT.transform.position + " Magnitude " + rbT.velocity.magnitude);
            //CreateBoundShot(rb.transform.position, rb.rotation, rb.velocity.magnitude, bulletColor.yellow);

        }

    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject bullet = other.gameObject;
        shooter.GetID();
        bullet.GetRB;
        shooter.GetID((shooter.Bullet)other);
        //get other velocity and reverse it
        if (other.tag == "Bound")
        {
            
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Vector2 pos = other.gameObject.transform.position;
        other.GetXSpeed()
        NewEnemyBulletScript.Bullet bulletRef = other.name as NewEnemyBulletScript.Bullet.collide;
            bulletRef.GetXSpeed();

        other.gameObject.SetActive(false);
        shooter.CreateBoundShot(pos )
        bullet.GetRB;
        shooter.GetID((shooter.Bullet)other);
        //get other velocity and reverse it
        if (other.tag == "Bound")
        {

        }

    }*/
}
