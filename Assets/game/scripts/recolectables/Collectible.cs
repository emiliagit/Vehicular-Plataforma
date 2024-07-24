using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject impact;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject hit = Instantiate(impact, transform.position, Quaternion.identity);
            Destroy(hit, 1f);
            Destroy(gameObject);
        }
    }
}
