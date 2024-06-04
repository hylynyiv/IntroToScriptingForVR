using UnityEngine;
using TMPro;

public class Speak : MonoBehaviour
{
    private TextMeshPro NPCText;

    void Start()
    {
        NPCText = GetComponent<TextMeshPro>();
        NPCText.text = "Hello World!";
    }
}
