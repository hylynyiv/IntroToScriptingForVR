using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise6 : MonoBehaviour
{
    private Renderer objRenderer;
    public bool change = false;
    private Color originalColor;
    public Color targetColor = new Color (1,0,0);
    private float changeDuration = 5f;
    private float elapsedTime = 0f;
    private bool isReturning = false;
    

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    void Update()
    {
        if (change == true){
            ColorChange(targetColor);
            change = false;
        }

        if (isReturning)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / changeDuration;

            // Gradually change back to the original color

            objRenderer.material.color = Color.Lerp(targetColor, originalColor, t);

            if (elapsedTime >= changeDuration)
            {
                isReturning = false; // Stop the transition after the duration
            }
        }
    }

    public void ColorChange(Color newColor)
    {
        targetColor = newColor;
        objRenderer.material.color = newColor;
        isReturning = true;
        elapsedTime = 0f; // Reset the timer
    }
}
