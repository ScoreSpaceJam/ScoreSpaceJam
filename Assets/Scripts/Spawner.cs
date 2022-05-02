//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool canIncRate = true;

    [Header("Flying Enemies Spawnpoints")]
    [SerializeField] Transform[] spawnPoints;

    [Header("Spawn Settings")]
    //Time
    float timer;
    [SerializeField] float rateOfSpawn;

    float uniTimer;
    [SerializeField] float incRateAfter = 30;

    void Start()
    {
    }

    void Update()
    {
        SpawningTimer();

        if(canIncRate)
        {
            RateIncreaser();
        }
    }

    void RateIncreaser()
    {
        uniTimer += Time.deltaTime;
        if(uniTimer > incRateAfter)
        {
            rateOfSpawn -= 0.2f;

            if(rateOfSpawn <= 0)
            {
                rateOfSpawn = 0.1f;
                canIncRate = false;
            }

            uniTimer = 0;
        }
    }

    void SpawningTimer()
    {
        timer += Time.deltaTime;
        if (timer > rateOfSpawn)
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
