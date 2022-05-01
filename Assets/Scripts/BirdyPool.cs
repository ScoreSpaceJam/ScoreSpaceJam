using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdyPool : MonoBehaviour
{
    public static BirdyPool instance;

    private List<GameObject> poolObject = new List<GameObject>();
    private int amountToPool;

    [SerializeField] GameObject[] objectToPool;
    [SerializeField] int amount;

    int totalArray;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        totalArray = objectToPool.Length;

        amountToPool = amount;
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool[Random.Range(0,totalArray)]);
            obj.SetActive(false);
            obj.transform.parent = transform;
            poolObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolObject.Count; i++)
        {
            if(!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }

        return null;
    }
}
