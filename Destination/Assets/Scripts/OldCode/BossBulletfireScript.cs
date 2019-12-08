using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletfireScript : MonoBehaviour {
    public float fireTime = .05f;
    public GameObject bulletObject;
    public int startingPoolSize;
    private List<GameObject> bossPool;

    // Use this for initialization
    void Start()
    {
        Pool(bulletObject, startingPoolSize);
        //InvokeRepeating("Fire", fireTime, fireTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 vect = new Vector2(3, -3);
            float sp = 8.0f;
            CreateShot(vect, 0.0f, sp);
           // FireNextBullet(vect);
        }
    }

    void Pool(GameObject type, int poolSize)
    {
        bossPool = MyObjectPoolerScript.current.BuildPool(type,poolSize);
    }

    void Fire<bulletObject>()
    {
        GameObject obj = MyObjectPoolerScript.current.GetPooledObject(bossPool);
        if (obj == null) return;
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        //obj.Instance.RB.velocity;
        //obj.RB
        obj.SetActive(true);
    }

    void CreateShot(Vector2 startPosition, float rotation, float speed)
    {
        Debug.Log("Before GetPooled Current is "+ AppleScript.current.ToString());
        GameObject obj = MyObjectPoolerScript.current.GetPooledObject(bossPool);
        if (obj == null) return;
        obj.transform.position = startPosition;
        //obj.transform.rotation = rotation;
        obj.transform.rotation = Quaternion.Euler(0,0, rotation);
        int foo = obj.GetInstanceID(); //same instance ID as object from appleScript
        //Debug.Log("RB: " + AppleScript.current.GetRB().ToString());
         Debug.Log(" after get pooledCurrent is: " + AppleScript.current.ToString()+ "  Obj is: " + obj.ToString() );
        //if (AppleScript.current.GetInstanceID()==foo) Debug.Log(AppleScript.current.GetInstanceID() + " == " + foo);
        //AppleScript.current.cRB.velocity = startPosition.normalized * speed;
        AppleScript.current.GetRB().velocity = startPosition.normalized * speed;
        Debug.Log("doneSettignVelocity");
        //AppleScript.current.GetRB().AddForce(AppleScript.current.transform.up * -speed);
        
        //obj.Instance.RB.velocity;
        //obj.RB
        obj.SetActive(true);
    }

    void CreateShotAtDest(Vector2 startPosition, Vector2 destinationPosition, float speed)
    {
        //TODO
    }

    //private GameObject GetNextPooled

}
