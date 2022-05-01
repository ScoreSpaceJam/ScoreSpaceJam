//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Flying Enemies Spawnpoints")]
    [SerializeField] Transform[] spawnPoints;

    [Header("Spawn Settings")]
    //Time
    float timer;
    [SerializeField] float rateOfSpawn;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > rateOfSpawn)
        {
            InstanciatingEnemy();
            timer = 0;
        }
    }

    void InstanciatingEnemy()
    {
        GameObject enemy = BirdyPool.instance.GetPooledObject();

        if(enemy != null)
        {
            enemy.transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
            enemy.SetActive(true);
        }
    }
}
