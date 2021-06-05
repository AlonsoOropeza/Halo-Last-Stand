using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float alturaSalto;
    [SerializeField] Transform groundChecker;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround()) {
            rb.AddForce(Vector3.up * alturaSalto, ForceMode.Impulse);
        }
    }

    bool IsOnGround() 
    {
        Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);
        if (colliders.Length > 0) {
            return true;
        } else {
            return false;
        }
    }
}
