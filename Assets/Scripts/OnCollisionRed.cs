using UnityEngine;

public class OnCollisionRed : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}


