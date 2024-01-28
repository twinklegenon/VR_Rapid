using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // Reference to the UI GameObject
    public GameObject objUI;

    // Duration in seconds for UI activation
    public float activationDuration = 300f; // 5 minutes

    private bool isActivated = false;

    // This function is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is a player or the object you want to interact with
        if (other.CompareTag("Selectable") && !isActivated)
        {
            // Activate the UI GameObject
            objUI.SetActive(true);

            // Set the flag to indicate activation
            isActivated = true;

            // Start a coroutine to deactivate the UI after a certain duration
            StartCoroutine(DeactivateUI());
        }
    }

    // Coroutine to deactivate the UI after a certain duration
    private System.Collections.IEnumerator DeactivateUI()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(activationDuration);

        // Deactivate the UI GameObject
        objUI.SetActive(false);

        // Reset the activation flag
        isActivated = false;
    }
}
