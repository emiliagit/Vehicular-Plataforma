using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{

    private bool canRecover;

    [SerializeField] private float groundcheckRayMaxDistance;
    [SerializeField] private Vector3 boxSize;

    [SerializeField] private float recoveryCooldown;
    // Start is called before the first frame update
    void Start()
    {
        canRecover = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canRecover)
            Recover();
    }

    private void Recover()
    {
        if (IsGrounded()) return;

        StartCoroutine(nameof(RecoverCooldown));
        transform.eulerAngles = new(0f, transform.eulerAngles.y, 0f);
    }

    private IEnumerator RecoverCooldown()
    {
        canRecover = false;

        yield return new WaitForSeconds(recoveryCooldown);

        canRecover = true;
    }

    private bool IsGrounded()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, groundcheckRayMaxDistance))
            return true;
        else
            return false;
    }
}
