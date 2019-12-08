using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletField : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            other.gameObject.SetActive(false);
        }
    }
// Update is called once per frame
void Update () {
		
	}

    private void FixedUpdate()
    {

    }
}
