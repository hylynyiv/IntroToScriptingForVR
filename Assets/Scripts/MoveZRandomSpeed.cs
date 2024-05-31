using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZRandomSpeed : MonoBehaviour
{
    public float speed = 1f;
    public float minSpeed = -3f;
    public float maxSpeed = 3f;
    public float changeInterval = 2.0f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0;
            speed = Random.Range(minSpeed, maxSpeed);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }
}


