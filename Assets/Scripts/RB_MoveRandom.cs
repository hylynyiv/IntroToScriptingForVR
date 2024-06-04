using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_MoveRandom : MonoBehaviour
{
    private float speedX;
    private float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float timer;
    public int boundary = 30;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetRandomDirAndSpeed(4f);
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= changeInterval)
        {
            timer = 0;
            SetRandomDirAndSpeed(4f);
        }

        // Apply movement by setting velocity
        rb.velocity = new Vector3(speedX, rb.velocity.y, speedZ);

        // Boundary Check
        if (Mathf.Abs(rb.position.x) >= boundary)
        {
            speedX = -speedX;
            rb.position = new Vector3(Mathf.Sign(rb.position.x) * boundary, rb.position.y, rb.position.z);
        }
        if (Mathf.Abs(rb.position.z) >= boundary)
        {
            speedZ = -speedZ;
            rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Sign(rb.position.z) * boundary);
        }
    }

    public void SetRandomDirAndSpeed(float maxInterval)
    {
        speedX = Random.Range(minSpeed, maxSpeed);
        speedZ = Random.Range(minSpeed, maxSpeed);
        changeInterval = Random.Range(1f, maxInterval);
    }
}
