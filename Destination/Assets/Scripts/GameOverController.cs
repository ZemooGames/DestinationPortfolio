using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

    // Use this for initialization
    public int lives;
    public float blinkLow;
    private SpriteRenderer spRend;
    private Color colorLow;
    private Color colorHigh;
    public PlayerController player;
    public Controller control;

    // Use this for initialization
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        colorHigh = spRend.color;
        Color temp = spRend.color;
        temp.a -= 1;
        temp.a += blinkLow;
        colorLow = temp;
        spRend.color = colorLow;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.lives < 1)
        if(player.IsGameOver())
        {
            spRend.color = colorHigh;
            if (Input.GetKeyDown(KeyCode.R))
            {
                control.ResetScene();
            }

            
        }
  
    }
}
