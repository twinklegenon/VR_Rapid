using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InteractiveObject : MonoBehaviour
{
    public GameObject interactionIndicator;
    public InputActionProperty showButton;
    public Animator objectAnimator;
    public GameObject objectToActivate;
    public float delayTime;
    private bool animationActivated = false;
   

    private void Start()
    {
        HideIndicator();
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (distance < 2.8f)
        {
            ShowIndicator();

            if (!animationActivated && showButton.action.triggered)
            {
                ActivateAnimation();
                StartCoroutine(ActivateObjectAfterDelay(delayTime));
            }
        }
        else
        {
            HideIndicator();
        }
    }

    private void ShowIndicator()
    {
        interactionIndicator.SetActive(true);
    }

    private void HideIndicator()
    {
        interactionIndicator.SetActive(false);
    }

    private IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ActivateGameObject();
    }

    private void ActivateGameObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    private void ActivateAnimation()
    {
        if (objectAnimator != null)
        {
            objectAnimator.SetTrigger("Activate");
            animationActivated = true;
        }
    }
}
