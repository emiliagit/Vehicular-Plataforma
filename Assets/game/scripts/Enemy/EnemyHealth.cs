using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;

   
    private GameObject FireEfect2;

    public GameObject damageEfectEnemies;

    public Transform damageEfectPoint2;

   
    bool fireEffectSpawned2 = false;


    public GameObject deathEffect;

    private void Start()
    {

    }


    private void Update()
    {
       
        if (enemyHealth <= 30 && !fireEffectSpawned2)
        {
            DamageEnemies();
            fireEffectSpawned2 = true;
        }
        if (enemyHealth <= 0)
        {
            Die();
        }

    }
    public void TakeDamage(float damage)
    {

        enemyHealth -= damage;

    }


    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
          
        }

        Destroy(gameObject);
        //Destroy(FireEfect1);
        Destroy(FireEfect2);
    }

   

    private void DamageEnemies()
    {
        FireEfect2 = Instantiate(damageEfectEnemies, damageEfectPoint2.position, damageEfectPoint2.rotation);
    }
}
