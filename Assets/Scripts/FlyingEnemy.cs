//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float addScore = 1;
    [SerializeField] float healthDeduct = 1;

    [SerializeField] int maxHealth = 1;
    int Health = 1;

    GameObject[] towers;
    Vector3 finalLocation;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float minMoveSpeed;

    float timer;
    [SerializeField] float waitForDeath = 1;

    public GameObject effect;
   // public AudioSource deathSound;

    void Start()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        Health = maxHealth;
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
        CMShakeScript.Instance.CameraShake(1, 0.2f);
        GameObject.FindGameObjectWithTag("TowerHolder").GetComponent<Health>().currentHealth -= healthDeduct;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("TowerHolder").GetComponent<Health>().currentScore += addScore;
            Debug.Log("Collision");
            Health -= 1;
            if(Health <= 0)
            {
                CMShakeScript.Instance.CameraShake(1, 0.2f);
                Health = maxHealth;
               // deathSound.Play();
                Instantiate(effect, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }

}
