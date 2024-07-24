using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHEalth : MonoBehaviour
{
    public float currentHealth;

    private GameObject FireEfect1;
    private GameObject FireEfect2;

    public GameObject damageEfectEnemies;
    public Transform damageEfectPoint1;
    public Transform damageEfectPoint2;

    bool fireEffectSpawned1 = false;
    bool fireEffectSpawned2 = false;

    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 100 && !fireEffectSpawned1)
        {
            DamageBoss();
            fireEffectSpawned1 = true;
        }
        if (currentHealth <= 40 && !fireEffectSpawned2)
        {
            DamageBoss2();
            fireEffectSpawned2 = true;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;

    }

    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);

        }

        Destroy(gameObject);
        Destroy(FireEfect1);
        Destroy(FireEfect2);
       
    }

    private void DamageBoss()
    {
        FireEfect1 = Instantiate(damageEfectEnemies, damageEfectPoint1.position, damageEfectPoint1.rotation);
        FireEfect1.transform.SetParent(transform);
    }

    private void DamageBoss2()
    {
        FireEfect2 = Instantiate(damageEfectEnemies, damageEfectPoint2.position, damageEfectPoint2.rotation);
        FireEfect2.transform.SetParent(transform);
    }
}
