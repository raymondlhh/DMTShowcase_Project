using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    private Vector2 startTouch0, startTouch1;
    private float startDistance;
    private Vector3 startScale;

    public float rotationSpeed = 0.2f;
    public float scaleSpeed = 0.01f;
    public float minScale = 0.1f;
    public float maxScale = 2.0f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Rotate
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0, -rotX, 0, Space.World);
            }
        }
        else if (Input.touchCount == 2)
        {
            // Scale
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchOne.phase == TouchPhase.Began)
            {
                startTouch0 = touchZero.position;
                startTouch1 = touchOne.position;
                startDistance = Vector2.Distance(startTouch0, startTouch1);
                startScale = transform.localScale;
            }

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                float scaleFactor = (currentDistance - startDistance) * scaleSpeed;
                Vector3 targetScale = startScale + Vector3.one * scaleFactor;

                // Clamp scale
                targetScale = Vector3.Max(Vector3.one * minScale, targetScale);
                targetScale = Vector3.Min(Vector3.one * maxScale, targetScale);

                transform.localScale = targetScale;
            }
        }
    }
}

