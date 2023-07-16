using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationLoop : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private bool isClockwise = true;

    void Update()
    {
        transform.Rotate(Vector3.up, isClockwise ? rotationSpeed * Time.deltaTime : -rotationSpeed * Time.deltaTime);
    }
}