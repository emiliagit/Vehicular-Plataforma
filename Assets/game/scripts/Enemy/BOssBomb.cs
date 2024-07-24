using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOssBomb : MonoBehaviour
{
    // Prefab de la bomba
    public GameObject bombPrefab;

    // Punto de generación de la bomba
    public Transform spawnPoint;

    // Tiempo entre cada generación de bomba
    public float spawnInterval = 3.0f;

    // Inicializa el generador de bombas
    void Start()
    {
        StartCoroutine(SpawnBombs());
    }

    // Corrutina para generar bombas cada cierto tiempo
    IEnumerator SpawnBombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBomb();
        }
    }

    // Método para generar una bomba
    void SpawnBomb()
    {
        Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
