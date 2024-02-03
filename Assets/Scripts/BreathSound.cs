using UnityEngine;

public class BreathSound : MonoBehaviour
{
    public AudioClip breathSound; // Drag and drop the breath sound clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the breath sound clip to the AudioSource
        audioSource.clip = breathSound;
    }

    public void PlayBreathSound()
    {
        // Check if the breath sound clip is assigned
        if (breathSound != null)
        {
            // Play the breath sound clip
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No breath sound clip assigned. Drag and drop a breath sound clip in the Inspector.");
        }
    }

    public void StopBreathSound()
    {
        // Stop the breath sound clip
        audioSource.Stop();
    }
}
