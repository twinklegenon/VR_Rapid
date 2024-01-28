using UnityEngine;

public class RayInteractionController : MonoBehaviour
{
    public GameObject rayInteractor; // Reference to your ray interactor object
    private bool activationPending = true;
    private float activationDelay = 5f;

    void Update()
    {
        // Check if activation is pending
        if (activationPending)
        {
            // Update the delay timer
            activationDelay -= Time.deltaTime;

            // Check if the delay has elapsed
            if (activationDelay <= 0f)
            {
                // Enable the ray interactor
                rayInteractor.SetActive(true);

                // Deactivate further checks
                activationPending = false;
            }
        }

        // Check for the index button press to deactivate the ray interactor
        if (!activationPending && Input.GetButtonDown("IndexButton"))
        {
            // Disable the ray interactor
            rayInteractor.SetActive(false);
        }
    }
}
