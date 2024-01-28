using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 1f;

            // Calculate the direction from the object to the grab point
            Vector3 directionToGrabPoint = (objectGrabPointTransform.position - transform.position).normalized;

            // Calculate the new position based on the direction and distance
            Vector3 newPosition = transform.position + directionToGrabPoint * Time.deltaTime * lerpSpeed;

            // Move the Rigidbody to the new position
            objectRigidbody.MovePosition(newPosition);

            // Rotate the object to face the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToGrabPoint, Vector3.up);
            objectRigidbody.MoveRotation(targetRotation);
        }
    }
}
