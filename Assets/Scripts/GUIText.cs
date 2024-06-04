using UnityEngine;
using TMPro;

public class GUIText : MonoBehaviour
{
    private TextMeshProUGUI uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        uiText.text = "Hello World!";
    }
}

