using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSystem : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnDisable()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
