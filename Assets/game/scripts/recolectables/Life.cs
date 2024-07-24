using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    public GameObject hitLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.RecibirVida(20);
            GameObject hit = Instantiate(hitLife, transform.position, Quaternion.identity);
            Destroy(hit, 1f);
            Destroy(gameObject);

        }
    }
}
