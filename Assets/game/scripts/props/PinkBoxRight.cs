using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PinkBoxRight : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f; 

    private Vector3 originalPosition; 
    private bool movingRight = true; 

    void Start()
    {
       
        originalPosition = transform.position;
    }

    void Update()
    {
        MoovingRight();
    }

    void MoovingRight()
    {
       
        Vector3 targetPosition;
        if (movingRight)
        {
            targetPosition = originalPosition + new Vector3(moveDistance, 0, 0);
        }
        else
        {
            targetPosition = originalPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingRight = !movingRight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.RecibirDanio(5);
        }
    }
}
