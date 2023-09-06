using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    public float targetRotationY = 0f;
    public float rotationSpeed = 90f; // Adjust the speed of rotation here
    private bool isRotating = false;
    private Quaternion initialRotation;
    public WheelCollider wheelCollider;
    private Vector3 currentPosition;

    void Start()
    {
        // Store the initial rotation of the object
    }

    void Update()
    {
        initialRotation = transform.rotation;
        currentPosition = transform.position;

        WheelHit hit;
        bool isColliding = wheelCollider.GetGroundHit(out hit);

        if (isColliding)
        {
            // The wheel is colliding with something
            Collider otherCollider = hit.collider;
            Vector3 contactPoint = hit.point;
            Vector3 contactNormal = hit.normal;

            // You can perform additional actions based on the collision here
        }
        else
        {
            // The wheel is not colliding with anything
        if (isRotating)
        {

                // Calculate the step to rotate smoothly based on time and rotationSpeed
                float step = rotationSpeed * Time.deltaTime;

            // Calculate the target rotation with only the Y-axis modified
            Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, targetRotationY);

            // Rotate the object towards the target Y rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            // Check if the rotation is almost equal to the target
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                isRotating = false; // Stop rotating
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
                currentPosition.y += 5f;
                transform.position = currentPosition;

                isRotating = true; // Start rotating when the Space key is pressed
        }
        }

    }

}
