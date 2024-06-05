using UnityEngine;
using TMPro;

public class SpeakOnCollision : MonoBehaviour
{
    private TextMeshPro NPCText;
    private float timer;
    private bool textOn = false;
    public string[] speech = { "Hello", "Sorry", "Do I know you?", "Apologize!", "You stepped on my tail, you monster!" };

    void Start()
    {
        // Find TextMeshPro component among siblings
        NPCText = transform.parent.GetComponentInChildren<TextMeshPro>();

        if (NPCText == null)
        {
            Debug.LogError("TextMeshPro object not found.");
        }
        else
        {
            NPCText.text = speech[0];
            textOn = true;
            Debug.Log("Initial text set to: " + NPCText.text);
        }
    }

    void Update()
    {
        // Blank the text after 3 seconds to better see when a collision happens
        if (textOn)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                NPCText.text = "";
                textOn = false;
                timer = 0;
                Debug.Log("Text blanked after 3 seconds.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (NPCText != null)
        {
            NPCText.text = speech[Random.Range(0, speech.Length)];
            textOn = true;
            Debug.Log("Collision detected, text set to: " + NPCText.text);
        }
        else
        {
            Debug.LogError("NPCText is null in OnCollisionEnter.");
        }
    }
}
