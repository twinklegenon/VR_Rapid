using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Unity.XR.CoreUtils.GUI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class ObjectMovement : MonoBehaviour
{
    public Transform _target;
    public float _speed;
    public InputActionReference _triggerAction; // Input action reference for triggering movement

    private bool isMoving = false;

    private void OnEnable()
    {
        _triggerAction.action.Enable();
        _triggerAction.action.performed += OnTriggerAction;
    }

    private void OnDisable()
    {
        _triggerAction.action.Disable();
        _triggerAction.action.performed -= OnTriggerAction;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerAction(InputAction.CallbackContext context)
    {
        StartCoroutine(TriggerMovementAfterDelay(5f));
    }

    private IEnumerator TriggerMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;
    }
}
