using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpeedDisplay : MonoBehaviour
{
    public WheelCollider[] wheelColliders; // Reference to your WheelColliders
    public Text wheelSpeed;
    void Update()
    {
        // Calculate the average angular velocity of all the wheel colliders
        float averageAngularVelocity = 0f;
        foreach (WheelCollider wheel in wheelColliders)
        {
            averageAngularVelocity += wheel.rpm * 6.0f * Mathf.PI; // Convert RPM to meters per second
        }
        averageAngularVelocity /= wheelColliders.Length;

        // Display the car's speed in the console
        float speedInKMH = averageAngularVelocity * 3.6f; // Convert meters per second to kilometers per hour
        /* Debug.Log("Car Speed: " + Mathf.Abs(speedInKMH/1000f).ToString("F2") + " km/h");*/
        wheelSpeed.text = Mathf.Floor(Mathf.Abs(speedInKMH)/1000).ToString() + " km/h";
    }
}
