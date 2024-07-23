using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBombs : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ProyectilePlayer"))
        {
            GameObject fire = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(fire, 1f);
            Destroy(gameObject);
        }
        if(other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.RecibirDanio(5);
        }
    }
}
