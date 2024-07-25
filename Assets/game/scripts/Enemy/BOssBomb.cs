using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOssBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3.0f;

    public float detectionRadius = 6f;

    public Transform player;

    private bool isSpawning = false;
    private Coroutine spawnCoroutine;


    void Start()
    {
        
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            if (!isSpawning)
            {
                spawnCoroutine = StartCoroutine(SpawnBombs());
            }
        }
        else
        {
            if (isSpawning)
            {
                StopCoroutine(spawnCoroutine);
                isSpawning = false;
            }
        }
    }


    public IEnumerator SpawnBombs()
    {
        isSpawning = true;
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBomb();
        }
    }


    public void SpawnBomb()
    {
        Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
    }



}
