using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectPoolerScript : MonoBehaviour {

    public static MyObjectPoolerScript current;
    public GameObject pooledObject;
    //   public GameObject Parent;
    public int pooledAmount;
    public bool willGrow;

    List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    public List<GameObject> BuildPool(GameObject type, int poolSize)
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.transform.parent = transform;
            obj.name = pooledObject.name + i;
            //obj.Instance.RB.velocity;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        return pooledObjects;
    }

    public GameObject GetPooledObject(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                //Debug.Log("MYPOOL" +list[i].GetInstanceID());
                return list[i];
            }
        }

 /*       if (willGrow)
        {
            //this will not work as-is needs to inherit pooled object type GameObject obj = (GameObject)Instantiate(pooledObject);
            list.Add(obj);
            return obj;
        }
  */
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
