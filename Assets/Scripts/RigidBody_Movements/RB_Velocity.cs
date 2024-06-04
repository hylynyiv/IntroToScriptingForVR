using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Velocity : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * speed; // Set initial velocity
    }

    void FixedUpdate()
    {
        // Maintain forward velocity but let gravity affect the Y-axis
        Vector3 velocity = rb.velocity;
        velocity.z = speed;
        rb.velocity = velocity;
        //The reason you cannot write rb.velocity.z = speed directly is that
        //rb.velocity returns a Vector3 struct, and in C#, structs are value types.
        //This means that rb.velocity returns a copy of the Vector3, and modifying
        //this copy does not affect the actual velocity of the Rigidbody.


        // To override gravity:
        //rb.velocity = Vector3.forward * speed; // because Vector3.forward is (0, 0, 1)
        // so we are overwriting thy y velocity with 0


    }
}
