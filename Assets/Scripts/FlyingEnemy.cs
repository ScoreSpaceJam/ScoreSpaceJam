//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    GameObject[] towers;
    Vector3 finalLocation;
    [SerializeField] float moveSpeed;

    float timer;
    [SerializeField] float waitForDeath = 1;

    void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Tower");
        finalLocation = towers[Random.Range(0, towers.Length)].transform.position;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, finalLocation) <= 0)
        {
            timer += Time.deltaTime;
            if(timer > waitForDeath)
            {
                Death();
                timer = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, finalLocation, moveSpeed * Time.deltaTime);
    }
    
    void Death()
    {
        //In death sec instead of destroying the object we need to unactivate the enemy and reseting its health...
        gameObject.SetActive(false);
    }

}
