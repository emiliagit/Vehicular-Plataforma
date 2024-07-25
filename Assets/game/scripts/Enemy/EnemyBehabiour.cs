using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehabiour : MonoBehaviour
{
    //shooting
    public Transform player;

    public EnemyAim aim;

    public GameObject projectilePrefab; 
    public Transform projectileSpawnPoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float bulletForce = 7f;

    public float detectionRadius = 6f;



    void Start()
    {

    }

   
    void Update()
    {

        aim.TurretAim();

       
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
           
            if (Time.time >= nextFireTime)
            {
                AttackPlayer();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

    }

    private void AttackPlayer()
    {
        Vector3 directionToPlayer = (player.position - projectileSpawnPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.LookRotation(directionToPlayer));

       
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = directionToPlayer * bulletForce;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

   
}
