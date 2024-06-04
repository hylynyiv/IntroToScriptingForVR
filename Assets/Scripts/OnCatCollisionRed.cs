using UnityEngine;

public class OnCatCollisionRed : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cats"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}


