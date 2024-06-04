using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ColorChange(Color myColor)
    {
        GetComponent<Renderer>().material.color = myColor;
    }
}

