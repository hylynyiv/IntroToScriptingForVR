using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_AddForce : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * force * Time.deltaTime);
    }
}

