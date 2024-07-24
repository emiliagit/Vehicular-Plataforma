using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOssBomb : MonoBehaviour
{
    // Prefab de la bomba
    public GameObject bombPrefab;

    // Punto de generaci�n de la bomba
    public Transform spawnPoint;

    // Tiempo entre cada generaci�n de bomba
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

    // M�todo para generar una bomba
    void SpawnBomb()
    {
        Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
