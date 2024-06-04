using UnityEngine;

// Exercise1 5 Prompt:
// 1. Create a script that changes the object color to a custom color.

public class Exercise5 : MonoBehaviour
{
    // Declare the variable here to make it accessible to all methods of the class.
    private Renderer objRenderer;
    private float timer;
    public float updateInterval = 0.5f;

    void Start()
    {
        // Initialize the variable by getting the Renderer component once and
        // store it for later use for computational efficiency and convenience.
        objRenderer = GetComponent<Renderer>();
        // Change the color with our custom method.
        ColorChange();
    }

    void Update()
    {
        // 2. Make this color change in a randomized manner 2 times per second.
        timer += Time.deltaTime;

        if(timer >= updateInterval)
        {
            Debug.Log(timer); // Let's monitor the timer to see if the update frequency is correct.
            ColorChange();
            timer = 0f;          
        }
    }

    void ColorChange()
    {
        // Assign a new color with random color values to the color property of the material.
        objRenderer.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
