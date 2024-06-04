using UnityEngine;

public class RB_TransformPosition : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; 
    }
}

