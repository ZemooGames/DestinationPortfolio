using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
public class EnemyShotMover : MonoBehaviour {
    private Rigidbody2D RB;
    private GameObject obj;
    private Animator anim;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        obj = this.gameObject;
	}
	

    public void CreateShot(Vector2 position, Vector2 velocity, string sprite)
    {
        transform.position = position;
        RB.velocity = velocity;
        obj.SetActive(true);
    }
}
