using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour {
    //private Controller controller;
    public static AppleScript current;
    public GameObject prefab;
    static Rigidbody2D RB;
    //maybe get rid of static
    public Rigidbody2D currentRB;// currently set to it's own rigid body in the inspector shouldn't need to set it or update it
    public Rigidbody2D cRB;
    public Animator anim;

    enum AppleColor
    {
        red,
        blue,
        yellow,
        magenta,
        teal,
        chartruse
    }

	// Use this for initialization
	void Start () {
        // PoolManager.instance.CreatePool(prefab, 200);
        //controller = Controller.Instance();
        //start doesn't work for these cause they are created by the pooler
        
	}

    private void Awake()
    {
        //if (current == null)
        //{
           // current = this;
       // }
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(currentRB == null)
        {
            //currentRB = RB;
        }
        
        //This is called when bullets are made, only once per bullet
        Debug.Log("AWAKE " +GetInstanceID() + " RB: " + RB.ToString() + " Anim: " + anim.ToString());

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
  
        }
        // AppleScript.currentRB = this;
        //cRB = currentRB;
        Debug.Log("Current is: " + current.ToString() + "  RB is: " + RB.ToString() + "  CurrentRB is: " + currentRB.ToString());
    }
   
    public int CreateShot(Vector3 position/*, float speed, Quaternion dir, AppleColor color*/)
    {
        /* currently not used
        //public GameObject shot;
        Debug.Log("AppleScript log");
        this.transform.position.Set(position.x,position.y,position.z);
        RB.velocity.Set(2,0);
        //current.transform.position.Set(position.x, position.y, position.z);
        //RB.velocity.Set(speed.x, speed.y);
        //PoolManager.instance.ReuseObject(prefab, position, dir);
        // this uses the prefab in the constructor, not an apple inthe pool? I think
*/
        return prefab.GetInstanceID();
        
    }
    private void OnEnable()
    {
        current = this;
        Debug.Log("OnEnable currentSet to "+ current.ToString());
        //currentRB = this.GetRB();
    }
    private void OnDisable()
    {

    }

    public void setCurrent(GameObject obj)
    {
       // current = obj;
      // obj.CreateShot();
    
    }

    public Rigidbody2D GetRB()
    {
        cRB = currentRB;
        return cRB;
    }

    public Animator GetAnim()
    {
        return anim;
    }
}
