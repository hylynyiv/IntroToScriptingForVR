using UnityEngine;

public class TriggerColorChanger : MonoBehaviour
{
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        objRenderer.material.color = Color.red;
    }
}


