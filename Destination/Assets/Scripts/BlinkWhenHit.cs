using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkWhenHit: MonoBehaviour {

    public string[] PositiveColliders;
    public string[] NegativeColliders;
    private int frame;
    public int blinkTime;//200 frames
    public int blinkRate;// 8 frames
    public bool blinking;
    public float blinkLow;
    private SpriteRenderer spRend;
    private Color colorLow;
    private Color colorHigh;

    // Use this for initialization
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        colorHigh = spRend.color;
        Color temp = spRend.color;
        temp.a -= 1;
        temp.a += blinkLow;
        colorLow = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinking && Time.timeScale == 1)
        {
            frame++;

            if (frame >= blinkTime)
            {
                frame = 0;
                blinking = false;
                spRend.color = colorHigh;
            }
            else if (frame % blinkRate == 0)
            {
                //Debug.Log(frame + "Blinking  "+ spRend.color);
                if(spRend.color.a == 1)
                {
                    spRend.color = colorLow;
                }else
                {
                    spRend.color = colorHigh;
                }

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Component.Collider2D.rad
        //    collision.collider.
        foreach (string i in PositiveColliders)
        {
            if (other.tag == i)
            {
                blinking = true;
                //frame = 0;
                //Debug.Log("PKK");
                //other.gameObject.SetActive(false);
            }
        }

    }
}
