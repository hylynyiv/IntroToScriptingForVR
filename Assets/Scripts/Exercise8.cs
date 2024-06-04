using UnityEngine;
using TMPro;

public class Exercise8 : MonoBehaviour
{
    private TextMeshPro NPCText;
    private float timer;


    public string[] speech = { "Hello", "Sorry", "Do I know you", "Apologize!"}; 

    void Start()
    {
        NPCText = GetComponent<TextMeshPro>();

        NPCText.text = speech[0];
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2f)
        {
            NPCText.text = speech[Random.Range(0, speech.Length)];
        }
        
    }
}
