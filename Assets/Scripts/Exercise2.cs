using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Exercise 2 Prompt:

// 1. Improve the previous script so that Garfield moves in random directions 
// (except upwards and downwards).

// 2. How can we prevent Garfield to wander off too far from the playing area?


public class Exercise2 : MonoBehaviour
{
    public float speedX;
    public float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float timer;
    // defining a boundary
    public int boundary = 10;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0;
            speedX = Random.Range(minSpeed, maxSpeed);
            speedZ = Random.Range(minSpeed, maxSpeed);
        }

        transform.position += new Vector3(speedX, 0, speedZ) * Time.deltaTime;


        // We include a mechanism to prevent Garfield to wander off too far
        // Mathf.Abs() uses the absolute value of a number, so that we don't have
        // to write code for positive and negative values
        if (Mathf.Abs(transform.position.x) >= boundary)
        {
            speedX = -speedX; // we will just invert the existing value
            // we want to set the objects position directly at the boundary to
            // avoid it gets stuck oscillating around it because of tiny floating
            // point imprecisions
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * boundary, 0, transform.position.z);
            // Mathf.Sign keeps track of the value's sign, so that the direction is maintained
        }

        if (Mathf.Abs(transform.position.z) >= boundary)
        {
            speedZ = -speedZ;
            transform.position = new Vector3(transform.position.x, 0, Mathf.Sign(transform.position.z) * boundary);
        }
    }
}

