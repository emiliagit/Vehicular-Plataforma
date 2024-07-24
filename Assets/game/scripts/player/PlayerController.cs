using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //movimiento
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public float wheelsRotationSpeed = 200.0f;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    private float recoveryCooldown;

    //salto
    private int saltosRestantes = 2;
    public float fuerzaSalto = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool grounded;

    //layer
    public LayerMask groundLayer;


    //recovery
    private Quaternion originalRotation;
    private bool isResettingRotation = false;
    private float recoverSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        originalRotation = transform.rotation;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotationWheels(moveInput, rotationInput);

        if (Input.GetButtonDown("Jump") && saltosRestantes > 0)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            isResettingRotation = true;
        }

        if (isResettingRotation)
        {
            ResetRotation();
        }


    }

    private void FixedUpdate()
    {
        MoveTankObj(moveInput);
        RotateTank(rotationInput);
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (grounded)
        {
            saltosRestantes = 2;
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        saltosRestantes--;
    }

    
    void MoveTankObj(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void RotationWheels(float moveInput, float rotationInput)
    {
        float wheelMoveRotation = moveInput * wheelsRotationSpeed * Time.deltaTime;
        float wheelTurnRotation = rotationInput * wheelsRotationSpeed * Time.deltaTime;

        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                if (wheelMoveRotation != 0f)
                    wheel.transform.Rotate(wheelMoveRotation, 0f, 0f);
                else
                    wheel.transform.Rotate(wheelTurnRotation, 0f, 0f);
            }
        }

        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                if (wheelMoveRotation != 0f)
                    wheel.transform.Rotate(wheelMoveRotation, 0f, 0f);
                else
                    wheel.transform.Rotate(-wheelTurnRotation, 0f, 0f);
            }
        }
    }

    void ResetRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * recoverSpeed);

        // Comprueba si la rotación está cerca de la original y detiene la interpolación
        if (Quaternion.Angle(transform.rotation, originalRotation) < 0.1f)
        {
            transform.rotation = originalRotation;
            isResettingRotation = false;
        }
    }
}
