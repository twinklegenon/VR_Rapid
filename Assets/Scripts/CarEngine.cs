using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public AudioClip engineSound;
    private AudioSource audioSource; // No need to assign in the inspector

    private void Start()
    {
        // If AudioSource is not assigned, create one at runtime
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = engineSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding GameObject has a specific tag (you can customize this)
        if (other.CompareTag("Player"))
        {
            // Play the car engine sound when triggered by player or push button
            audioSource.Play();
            Debug.Log("Car engine sound started.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding GameObject has a specific tag (you can customize this)
        if (other.CompareTag("Player") || other.CompareTag("StopEngine"))
        {
            // Stop the car engine sound when the trigger is exited by player or push button
            StopEngineSound();
            Debug.Log("Car engine sound stopped.");
        }
    }

    public void DisableCarEngine()
    {
        // Stop the car engine sound and disable the script
        StopEngineSound();
        enabled = false;
    }

    public void StopEngineSound()
    {
        // Stop the car engine sound
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Car engine sound stopped.");
        }
    }
}
