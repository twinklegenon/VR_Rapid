using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mousePosition;
    private float dragDistanceThreshold = 2f;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        float distance = Vector3.Distance(transform.position, currentPosition);

        if (distance <= dragDistanceThreshold)
        {
            transform.position = currentPosition;
        }
    }
}
