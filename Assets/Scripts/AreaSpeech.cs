using UnityEngine;

public class AreaSpeech : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    public string targetTag;

    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            // Log a message to the console when collision occurs
            Debug.Log("Collision with object tagged: " + targetTag);

            // Play the audio
            source.PlayOneShot(clip);

            // Log a message to the console when the audio is playing
            Debug.Log("Audio is playing.");
        }
    }
}