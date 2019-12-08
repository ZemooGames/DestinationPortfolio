using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotMover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D PlayerShot;

    //this is used by a couple things

    // Use this for initialization
    void Start()
    {
        PlayerShot = GetComponent<Rigidbody2D>();
        PlayerShot.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShot.velocity = transform.up * speed;
        Debug.Log(PlayerShot.velocity);
    }

    private void OnEnable()
    {

    }
}
