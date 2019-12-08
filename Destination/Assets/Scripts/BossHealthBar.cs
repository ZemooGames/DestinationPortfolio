using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour {

    public GameObject HealthBar;
    //public GameObject BgController;
    public BackgroundController BgController;
    public Animator Anim;
    private Sprite Sprite;
    //private SpriteRenderer Rend;
    public float MaxHP;
    public float HP;
    private int count = 20;
    private Vector3 temp;
    private GameObject BossHurtBullet;
    private GameObject Obj;
    private Renderer rend;
    private float HbScale = 6.4f;


    // Use this for initialization
    void Start()
    {
        Obj = GetComponent<GameObject>();
        rend = GetComponent<Renderer>();
        Sprite = HealthBar.GetComponent<Sprite>();
        //Rend = GetComponent<SpriteRenderer>();
        Anim = HealthBar.GetComponent<Animator>();
        switch (HealthBar.ToString())
        {
            case "HealthBar Red (UnityEngine.GameObject)":
                Anim.SetTrigger("red");
                this.tag = "red";
                break;
            case "HealthBar Blue (UnityEngine.GameObject)":
                Anim.SetTrigger("blue");
                this.tag = "blue";
                break;
            case "HealthBar Yellow (UnityEngine.GameObject)":
                Anim.SetTrigger("yellow");
                this.tag = "yellow";
                break;
            case "HealthBar Purple (UnityEngine.GameObject)":
                Anim.SetTrigger("purple");
                this.tag = "purple";
                break;
            default:
                Anim.SetTrigger("grey");
                this.tag = "grey";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count == 0)
        {
            count = 20;
            LowerHealth();

        }
        count--;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("NEW TRIG NEEDS ONE MORE" + other.tag + this.tag);
        
        if (other.tag == this.tag)
        //if (other.tag == "BossKiller")
        //if (other.tag == "BossKiller" && .GetAnim())
        {
            other.gameObject.SetActive(false);
            LowerHealth();
            //other.SetActive(false);
            //This kills the spikes and bosses
        }

    }

    void LowerHealth()
    {
        HP--;
        if (HP < 1)
        {
            //Destroy(Sprite, 0);
            BgController.RemoveColor(this.tag);
            //HealthBar.SetActive(false);
            rend.enabled = false;
            if (BgController.GetColor() == this.tag)
            {
                BgController.SwitchColor();
            }
            
            Debug.Log("OBJ " + Obj);
            //Obj.SetActive(false);
            
                //rendererSetActive(!gameObject.activeSelf);
        }
        else
        {
            //temp = HealthBar.transform.localScale;
            //temp.x = temp.x * HP / MaxHP;
            //float tempF = 
            temp = new Vector2((float)HP / MaxHP, HealthBar.transform.localScale.y);
            temp.x = HbScale * HP / MaxHP;
            //temp.
            Debug.Log("HP "+ HP + " MaxHP " + MaxHP + " HealthBar " + temp.x + " FLOAT " + temp);
            
            //tempF;
            HealthBar.transform.localScale = temp;
            Debug.Log("LOCAL Scale " + HealthBar.transform.localScale);
            //HealthBar.transform.
        }
    }
}
