using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2((transform.position.x + Time.deltaTime*speed) % 7.5f, transform.position.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            collision.gameObject.SetActive(false);
            //TODO create object pool for 1 bullet to shoot when hit here
        }
    }
}
