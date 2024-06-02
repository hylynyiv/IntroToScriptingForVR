using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5 : MonoBehaviour
{
    // Declare the variable here to make it accessible to all methods of the class
    private Renderer objRenderer;
    private float timer;
    public float updateInterval = 0.5f;

    void Start()
    {
        // Initialize the variable by getting the Renderer component once and
        // store it for later use for computational efficiency and convenience
        objRenderer = GetComponent<Renderer>();

        // Exercise1 5 Prompt:
        // 1. Create a script that changes the object color to a custom color.
        Color objColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        // Assign its value back to the color property of the material
        objRenderer.material.color = objColor;
    }

    void Update()
    {
        // 2. Make this color change in a randomized manner 2 times per second.
        timer += Time.deltaTime;

        if(timer >= updateInterval)
        {
            Debug.Log(timer);
            Color objColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            objRenderer.material.color = objColor;
            timer = 0f;          
        }
    }
}
