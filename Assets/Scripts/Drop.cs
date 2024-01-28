using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KinematicVelocityTracker : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rigidbody;

    private Vector3 lastPosition;
    private float lastTime;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();

        if (grabInteractable == null || rigidbody == null)
        {
            Debug.LogError("KinematicVelocityTracker requires XRGrabInteractable and Rigidbody components.");
            return;
        }

        grabInteractable.onSelectEntered.AddListener(OnSelectEnter);
        grabInteractable.onSelectExited.AddListener(OnSelectExit);

        // Ensure the Rigidbody is kinematic initially
        rigidbody.isKinematic = true;
    }

    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        // Set Rigidbody to non-kinematic when grabbed
        rigidbody.isKinematic = false;

        lastPosition = transform.position;
        lastTime = Time.time;
    }

    private void OnSelectExit(XRBaseInteractor interactor)
    {
        float deltaTime = Time.time - lastTime;
        Vector3 velocity = (transform.position - lastPosition) / deltaTime;

        Debug.Log("Object dropped with velocity: " + velocity.magnitude);

        // You can use the 'velocity' variable as needed (e.g., apply forces to the object).

        // Set Rigidbody back to kinematic when released
        rigidbody.isKinematic = true;
    }
}
