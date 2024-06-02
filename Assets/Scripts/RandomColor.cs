using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Declare the variable here to make it accessible to all methods of the class
    private Renderer objRenderer; 

    void Start()
    {
        // Initialize the variable by getting the Renderer component once and
        // store it for later use for computational efficiency and convenience
        objRenderer =  GetComponent<Renderer>();
    }

    void Update()
    {
        // Create a new random color
        Color objColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

        // Assign its value back to the color propertym of the material
        objRenderer.material.color = objColor;
    }
}
