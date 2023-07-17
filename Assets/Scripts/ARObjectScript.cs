using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectScript : MonoBehaviour
{
    [SerializeField] private float loopRotationSpeed = 10f;
    [SerializeField] private float manualRotationSpeed = 40f;
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float minSize = 0.35f;
    [SerializeField] private float maxSize = 2.5f;

    private float initialDistance;

    void Update()
    {
        if (Input.touchCount > 1)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch0.position, touch1.position);
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);
                float deltaDistance = initialDistance - currentDistance;
                float zoomAmount = deltaDistance * zoomSpeed * Time.deltaTime;

                // Perform Zooming
                Vector3 newScale = transform.localScale - new Vector3(zoomAmount, zoomAmount, zoomAmount);
                newScale.x = Mathf.Clamp(newScale.x, minSize, maxSize);
                newScale.y = Mathf.Clamp(newScale.y, minSize, maxSize);
                newScale.z = Mathf.Clamp(newScale.z, minSize, maxSize);
                transform.localScale = newScale;
            }
        }
        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = touch.deltaPosition;
                float rotationY = -deltaPosition.x * manualRotationSpeed * Time.deltaTime;

                // Perform swipe to rotate
                transform.Rotate(0f, rotationY, 0f);
            }
        }
        else if (Input.touchCount != 1)
        {
            // Perform rotation looping
            transform.Rotate(Vector3.up, loopRotationSpeed * Time.deltaTime);
        }
    }
}
