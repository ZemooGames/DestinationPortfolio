using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    //Must be Collider2D
    {
        //get other velocity and reverse it
        
        Vector2 v = rb.velocity;
        if (other.gameObject.name.ToString() == "Vertical Left" || other.gameObject.name.ToString() == "Vertical Right")
        {
            
            
            rb.velocity = new Vector2(-v.x,v.y);

            
            //Debug.Log("This should bounce" + v + " Other tag " + other.tag + " RB transform " + rb.transform.position + " Magnitude " + rb.velocity.magnitude);
            

        }
        if (other.gameObject.name.ToString() == "Horizontal Top"|| other.gameObject.name.ToString() == "Horizontal Bottom")
        {
          Debug.Log("ASDASD" + other.gameObject.name.ToString());
            //Vector2 v = rb.velocity;
            rb.velocity = new Vector2(v.x, -v.y);


            //Debug.Log("This should bounce" + v + " Other tag " + other.tag + " RB transform " + rb.transform.position + " Magnitude " + rb.velocity.magnitude);


        }
    }
}
