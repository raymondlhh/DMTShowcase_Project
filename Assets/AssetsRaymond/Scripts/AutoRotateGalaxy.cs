using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateGalaxy : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 5f;

    void Update()
    {
        // Rotate around Y-axis slowly
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}

