using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public GameObject Parent;
    public Animator Anim;
    private Sprite Sprite;
    private SpriteRenderer Rend;
    public float MaxHP;
    public float HP;
    private int count = 20;
    private Vector3 temp;

	// Use this for initialization
	void Start () {
        Sprite = GetComponent<Sprite>();
        //Rend = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        switch(Parent.ToString()){
            case "BossRed (UnityEngine.GameObject)":
                Anim.SetTrigger("red");
                break;
            case "BossBlue (UnityEngine.GameObject)":
                Anim.SetTrigger("blue");
                break;
            case "BossYellow (UnityEngine.GameObject)":
                Anim.SetTrigger("yellow");
                break;
            case "BossPurple (UnityEngine.GameObject)":
                Anim.SetTrigger("purple");
                break;
            default:
                Anim.SetTrigger("grey");
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (count == 0)
        {
            count = 20;
            //LowerHealth();

        }
        count--;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BossKiller")
        {
            //
            //.GetCurrentAnimatorStateInfo(0).IsName("Red")
            collision.gameObject.SetActive(false);
            Debug.Log("enter");
            LowerHealth();
            //collision.collider.SetActive(false);
            
        }
    }

    void LowerHealth()
    {
        HP--;
        if (HP < 1)
        {
            Destroy(Sprite,0);
        }
        else
        {
           // Debug.Log(HP / MaxHP);
            temp = transform.localScale;
            temp.x = temp.x * HP / MaxHP;
            transform.localScale = temp;
        }
    }

}
