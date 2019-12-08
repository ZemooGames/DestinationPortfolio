using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFireScript : MonoBehaviour
{
    public GameObject shotHolder;
    public GameObject apple;
    List<GameObject> bullets;
    public int pooledAmount;
    /*
    enum AppleColor
    {
        grey,
        red,
        blue,
        purple,
        yellow
    }

        */
    // Use this for initialization
    void Start()
    {
       Pool();
    }

    void Pool()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(apple);
            obj.SetActive(false);
            obj.transform.parent = transform;
            bullets.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 fuck = new Vector3(2,-2,0);
            //CreateShot(fuck, Quaternion.identity, 2.0f);
            FireNextBullet(fuck);
        }
    }


    void FireNextBullet(Vector3 position)
    {
        apple = NewObjectPoolerScript.current.GetPooledObject();
        int ID;
        ID = AppleScript.current.CreateShot(position);

        // if (obj == null) false;
        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;
        //obj.SetActive(true);
        // return true;            
    }
    /*
    public void CreateShot(Vector2 position, Quaternion rotation, float speed )
    {
        GameObject obj = NewObjectPoolerScript.current.GetPooledObject();
        //want this to return (Name, RigidBody2D, Animator

        if (obj == null) return;
        Debug.Log(obj.name.ToString());
        obj.transform.position = position;
        obj.transform.rotation =rotation;
     //   obj.rigidbody2D.velocity = speed;
        obj.SetActive(true);
    }*/
}
