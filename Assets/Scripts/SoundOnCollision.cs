using UnityEngine;

public class SoundOnCollision: MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource component found on this GameObject. Please add an AudioSource component.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
