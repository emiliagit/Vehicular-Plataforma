using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    public TextMeshProUGUI enemyCounterText;
    public PlayerHealth playerHealth;

    //public GameObject projectilePrefab;
    //public Transform[] projectileSpawnPoints;

    //public float projectileSpawnDelay = 1f; 
    //public float victoryDelay = 3f; 

    private GameObject[] keys;

    void Update()
    {
        CountKeys();
    }

    public void CountKeys()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        int keysCount = keys.Length;
        enemyCounterText.text = "Keys left: " + keysCount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckVictoryCondition();
        }
    }

    

    void CheckVictoryCondition()
    {
        if (keys.Length == 0 && playerHealth.hp > 0)
        {
            SceneManager.LoadScene("Victory");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
