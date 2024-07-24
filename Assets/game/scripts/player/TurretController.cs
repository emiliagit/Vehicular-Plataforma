using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    [SerializeField] private float spinSpeed;

    void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
        

        if (Input.GetMouseButton(4))
        {
            Debug.Log("rotando 4");
            transform.Rotate(Vector3.up, -spinSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(3))
        {
            Debug.Log("rotando 5");
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}
