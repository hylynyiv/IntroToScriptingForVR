using UnityEngine;
using TMPro;

public class SimpleSpeakOnCollision : MonoBehaviour
{
    private TextMeshPro NPCText;
    public string[] speech = { "Hello", "Sorry"};

    void Start()
    {
        NPCText = transform.parent.GetComponentInChildren<TextMeshPro>();
    }

    void OnCollisionEnter(Collision collision)
    {
        NPCText.text = speech[Random.Range(0, speech.Length)];
    }
}


