using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatOneBossHurtBullet : MonoBehaviour {

    public GameObject bullet;
    public Rigidbody2D rb;
    public Animator anim;

	// Use this for initialization
	void Start () {
        GameObject obj = (GameObject)Instantiate(bullet);
        rb = obj.GetComponent<Rigidbody2D>();
        anim = obj.GetComponent<Animator>();
        obj.SetActive(false);
        Debug.Log("OwO");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (obj.GetActive() == true)
        {
            rb.transform.position = this.transform.position;
            anim.SetTrigger("blue");
            Vector2 Move = new Vector2(3,5);
            rb.velocity = Move;
        }
    }
}
