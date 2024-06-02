using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        Material objMaterial = objRenderer.material;
        objMaterial.color = Color.red;
    }
}

