using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /* public Transform target; // Reference to the car's Transform
     public float smoothSpeed = 5f; // Adjust the smoothing speed
     public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the car's position

     private Vector3 desiredPosition;

     void LateUpdate()
     {
         // Calculate the desired position behind the car
         desiredPosition = target.position + target.TransformDirection(offset);

         // Use Lerp to smoothly interpolate between the current position and the desired position
         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

         // Set the camera's position to the smoothed position
         transform.position = smoothedPosition;

         // Make the camera look at the car
         transform.LookAt(target);
     }
 */

    public float moveSmoothness;
    public float rotSmoothness;

    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public Transform carTarget;

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 targetPos = new Vector3();
        targetPos = carTarget.TransformPoint(moveOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);
    }

    void HandleRotation()
    {
        var direction = carTarget.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);
    }
}
