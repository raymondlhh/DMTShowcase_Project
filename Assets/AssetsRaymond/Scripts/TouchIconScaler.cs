using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchIconScaler : MonoBehaviour
{
    private Vector3 originalScale = Vector3.one * 0.2f;
    private Vector3 targetScale;
    private bool isTouched = false;

    void Start()
    {
        transform.localScale = originalScale;
        targetScale = originalScale;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    isTouched = true;
                    targetScale = Vector3.one * 0.1f;
                }
                else
                {
                    isTouched = false;
                }
            }
            else
            {
                isTouched = false;
            }
        }
        else
        {
            isTouched = false;
        }

        // Return to original scale if not touched
        if (!isTouched)
        {
            targetScale = originalScale;
        }

        // Smooth transition
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 5f);
    }
}

