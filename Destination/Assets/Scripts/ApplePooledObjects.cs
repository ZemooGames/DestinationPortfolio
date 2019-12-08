using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePooledObjects : MonoBehaviour
{

    public static ApplePooledObjects current;
    public GameObject pooledObject;
    //   public GameObject Parent;
    public int pooledAmount;
    public bool willGrow;

    List<GameObject> pooledObjects;
    List<Animator> pooledAnimators;
    List<Rigidbody2D> pooledRigidbodys;

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.name = "EnemyBullet " + i;
            
            obj.SetActive(false);
            pooledObjects.Add(obj);
            Animator anim = obj.GetComponent<Animator>();
            pooledAnimators.Add(anim);
            Rigidbody2D RB = obj.GetComponent<Rigidbody2D>();
            pooledRigidbodys.Add(RB);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
