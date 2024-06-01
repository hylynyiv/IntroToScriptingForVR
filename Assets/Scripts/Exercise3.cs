using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Exercise 3 Prompt:

// Include a randomization of the changeInterval. I.e. it should be different
// every time to make the object's movement even more natural and less predictable.

public class Exercise3 : MonoBehaviour
{
    public float speedX;
    public float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float boundary = 20f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0;
            SetRandomDirSpeedInterval(4f);
        }
        transform.position += new Vector3(speedX, 0, speedZ) * Time.deltaTime;

        // Boundary Check
        if (Mathf.Abs(transform.position.x) >= boundary)
        {
            speedX = -speedX;
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * boundary, 0, transform.position.z);
        }
        if (Mathf.Abs(transform.position.z) >= boundary)
        {
            speedZ = -speedZ;
            transform.position = new Vector3(transform.position.x, 0, Mathf.Sign(speedZ) * boundary);
        }
    }

    // We are using a parameter to adjust the max interval time if necessary
    void SetRandomDirSpeedInterval(float maxInterval)
    {
        speedX = Random.Range(minSpeed, maxSpeed);
        speedZ = Random.Range(minSpeed, maxSpeed);
        changeInterval = Random.Range(1f, maxInterval);
    }
}

