using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomRefact : MonoBehaviour
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
            SetRandomDirAndSpeed();
        }
        transform.position += new Vector3(speedX, 0, speedZ) * Time.deltaTime;
    }

    void SetRandomDirAndSpeed() {
        speedX = Random.Range(minSpeed, maxSpeed);
        speedZ = Random.Range(minSpeed, maxSpeed);
    }
}

