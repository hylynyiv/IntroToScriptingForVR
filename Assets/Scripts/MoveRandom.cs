using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    public float speedX;
    public float speedZ;
    public float minSpeed = -4f;
    public float maxSpeed = 4f;
    public float changeInterval = 2.0f;
    public float timer;
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

        transform.position += new Vector3(speedX, 0 , speedZ) * Time.deltaTime;

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
}

