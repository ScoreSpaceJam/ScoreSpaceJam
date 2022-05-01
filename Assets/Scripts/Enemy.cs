using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] int incrementScore;

    private void Update()
    {
    }

    public void TakeDamage(int damage, bool fromPlayer)
    {
        health -= damage;
        if(health <= 0)
        {
            if(fromPlayer)
            {
                GameObject.FindGameObjectWithTag("TowerHolder").GetComponent<Health>().currentScore += incrementScore;
            }
            Destroy(gameObject);
        }
    }
}
