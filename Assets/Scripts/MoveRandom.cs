using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    public float speedX;
    public float speedZ;

    public float minSpeed = -0.1f;
    public float maxSpeed = 0.1f;

    public float changeInterval = 2.0f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0;
            speedX = Random.Range(minSpeed, maxSpeed);
            speedZ = Random.Range(minSpeed, maxSpeed);
        }
        transform.position = new Vector3(transform.position.x + speedX, transform.position.y, transform.position.z + speedZ );
    }
}

