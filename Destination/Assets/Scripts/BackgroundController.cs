using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    enum color
    {
        grey,
        red,
        blue,
        purple,
        yellow
    }
    //private string[] colors = {"grey","red","blue","purple","yellow"};
    private List<string> colors = new List<string> { "grey", "red", "blue", "purple", "yellow" };
    private Animator[] anims;
    public float time = 0.0f;
    public int frame = 0;
    public string bgColor = "grey";
    public NewEnemyBulletScript shooter;
    public GameObject player;
    public GameObject BossMain;
    private Vector2 BossPos;
    private Vector2 MouthPos = new Vector2(4.02f,-2.06f);
    public BossHealthBar BossRed;
    public BossHealthBar BossBlue;
    public BossHealthBar BossPurple;
    public BossHealthBar BossYellow;
    private int purpleAngle;
    private int purpleAngle2;//check if these angles are the in order
    private int[] purpleAdd = { 6, 10, 15, 20 };
    private int[] purpleAdd2 = { 5, 11, 16, 22 };

	// Use this for initialization
	void Start () {
        anims = GetComponentsInChildren<Animator>();
        BossPos = BossMain.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1) {
            frame++;
            time += Time.deltaTime;
            //int k = Mathf.RoundToInt(Random.Range(0, 5));
            if (frame > 600)
            {
                SwitchColor();
            }
            switch (bgColor)
            {
                case "red":
                    RedRoutine();
                    break;
                case "blue":
                    BlueRoutine();
                    break;
                case "yellow":
                    break;
                case "purple":
                    PurpleRoutine();
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        //the space bar isn't part of the game, just a dev tool for me right now
        {
            SwitchColor();
        }
    }

    public void SwitchColor()
    {
        Debug.Log("SWITCH");
        time = 0.0f;
        frame = 0;
        purpleAngle = 0;
        if (colors.Count == 1)
        {
            bgColor = colors[0];
            foreach (Animator animator in anims)
            {
                animator.SetTrigger(bgColor = colors[0]);
            }
        }else if (colors.Count ==0)
        {
            //Run end game here
            Debug.Log("U WIN");
            return;
        }
        else{
            int i = Mathf.RoundToInt(Random.Range(1, colors.Count));
            foreach (Animator animator in anims)
            {
                Debug.Log("Learn to hide bossess after they die  " + colors.Count);
                animator.SetTrigger(bgColor = colors[i]);
            }

        }
       
        
    }

    public void RedRoutine()
    {
        if (BossRed.HP > 12)
        {
            if (frame % 25 == 0)
            {
                shooter.CreateShot(MouthPos, shooter.GetAngle(MouthPos, player.transform.position), 6, shooter.GetEnumColor("red"));
            }
            if(frame % 4 == 0)
            {
                shooter.CreateShot(MouthPos, Random.Range(190f,350f), Mathf.FloorToInt(Random.Range(5, 7)), shooter.GetEnumColor("red"));
            }
        }
    }

    public void PurpleRoutine()
    {
        //Debug.Log("Time " + (time * 50 % 2));
        if (BossPurple.HP > 12)//purple 2 might not be right
        {
            if (frame % 5 == 0)
            {
                shooter.CreateShot(MouthPos, purpleAngle, 6, shooter.GetEnumColor("purple"));
                shooter.CreateShot(MouthPos, purpleAngle2 , 6, shooter.GetEnumColor("purple"));
                purpleAngle += 15;
                if (frame % 25 == 0)
                {
                    Vector2 origin = new Vector2(0.16f, 0.16f);
                    Vector2 origin2 = new Vector2(7.84f, 0.16f);
                    //Debug.Log("PURPLE RUT " + shooter.GetEnumColor("purple"));
                    shooter.CreateShot(origin, shooter.GetAngle(origin, player.transform.position), 6, shooter.GetEnumColor("purple"));
                    shooter.CreateShot(origin2, shooter.GetAngle(origin2, player.transform.position), 6, shooter.GetEnumColor("purple"));
                }
            }
        }else
        {
            if (frame % 6 == 0)
            {
                for(int i=0; i<3; i++)
                {
                    shooter.CreateShot(MouthPos, purpleAngle, Random.Range(4,7), shooter.GetEnumColor("purple"));
                    shooter.CreateShot(MouthPos, purpleAngle2, Random.Range(4,7), shooter.GetEnumColor("purple"));
                    purpleAngle += purpleAdd[Random.Range(0, purpleAdd.Length)];
                    purpleAngle2 += purpleAdd2[Random.Range(0, purpleAdd2.Length)];
                }
            }
        }
    }

    public void BlueRoutine()
    {
        if(frame % 30 == 0)
        {
            
            //int num = shooter.CreateShot(BossPos, shooter.GetAngle(BossPos, player.transform.position), 5, shooter.GetEnumColor("blue"));
            //shooter.SetScale(num,2.0f);
        }
    }

    public void YellowRoutine()
    {
        shooter.CreateBoundShot(MouthPos, 48, 6, shooter.GetEnumColor("yellow"));
    }

    public string GetColor()
    {
        return bgColor;
    }

    public void RemoveColor(string removeColor)
    {
        colors.Remove(removeColor);
        //check color if 2or 3 add upgrade?
    }

    public float F2T(int frames)
    {
        return 1.0f;
    }
}
