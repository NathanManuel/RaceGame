using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;


    public float acceleration = 500f;
    private float currentAcceleration = 0f;

    public float breackingForce = 300f;
    private float currentBreakForce = 0f;

    public float maxTurnAngle = 15f;
    private float currnetTurnAngle = 0f;



    void FixedUpdate()
    {
    if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breackingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }


        currentAcceleration = acceleration  * Input.GetAxis("Vertical") ;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currnetTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        frontRight.steerAngle = currnetTurnAngle;
        frontLeft.steerAngle = currnetTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }



    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
        /* frontRightTransform.Rotate(0, 10, 0);*/
    }

}
