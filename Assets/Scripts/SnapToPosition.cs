using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class SnapToPosition : MonoBehaviour
{
    public Transform[] snapPoints;
    public float snapDistance = 0.1f;
    public GameObject objectiveCompletionUI;

    void Update()
    {
        foreach (Transform snapPoint in snapPoints)
        {
            if (Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
            {
                SnapObject(snapPoint);
                DisplayObjectiveCompletion();
                break;
            }
        }
    }

    void SnapObject(Transform snapPoint)
    {
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;

        DisableRenderer(snapPoint);
        DisableGrabInteractable();
        DisableRigidbody();
    }

    void DisableRenderer(Transform snapPoint)
    {
        Renderer snapPointRenderer = snapPoint.GetComponent<Renderer>();
        if (snapPointRenderer != null)
        {
            snapPointRenderer.enabled = false;
        }
    }

    void DisableGrabInteractable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }
    }

    void DisableRigidbody()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void DisplayObjectiveCompletion()
    {
        // Activate the UI element for objective completion
        if (objectiveCompletionUI != null)
        {
            objectiveCompletionUI.SetActive(true);
            Debug.Log("Displaying Objective Completion");
        }
    }
}
