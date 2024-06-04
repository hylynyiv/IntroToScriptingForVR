using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f * Time.deltaTime);
    }
}

