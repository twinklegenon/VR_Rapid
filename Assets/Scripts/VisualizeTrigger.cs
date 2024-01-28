using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColliderVisualizer : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Start()
    {
        // Get the Box Collider component attached to the same GameObject
        boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            Debug.LogError("ColliderVisualizer requires a Box Collider component!");
        }
    }

    private void OnDrawGizmos()
    {
        if (boxCollider != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
        }
    }
}

