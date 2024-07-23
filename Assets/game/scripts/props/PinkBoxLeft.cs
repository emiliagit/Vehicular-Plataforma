using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBoxLeft : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f; 

    private Vector3 originalPosition;
    private bool movingLeft = true;

    void Start()
    {
       
        originalPosition = transform.position;
    }

    void Update()
    {
       MoovinLeft();
    }
    void MoovinLeft()
    {
        
        Vector3 targetPosition;
        if (movingLeft)
        {
            targetPosition = originalPosition - new Vector3(moveDistance, 0, 0);
        }
        else
        {
            targetPosition = originalPosition;
        }

       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        
        if (transform.position == targetPosition)
        {
           
            movingLeft = !movingLeft;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.RecibirDanio(5);
        }
    }
}
