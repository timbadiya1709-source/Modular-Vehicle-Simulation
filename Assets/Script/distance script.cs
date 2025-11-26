using UnityEngine;
using UnityEngine.UI;

public class CarTripMeter : MonoBehaviour
{
    public WheelCollider wheelCollider;  // Reference to the car's wheel collider
    public float wheelRadius = 0.35f;    // Radius of the wheel in meters
    public Text tripText;                // Reference to the UI Text for displaying the trip distance

    private float totalDistance = 0f;    // Total distance traveled by the car (in kilometers)

    void Update()
    {
        // Calculate the wheel circumference (C = 2 * π * r)
        float wheelCircumference = 2 * Mathf.PI * wheelRadius;

        // Get the RPM of the wheel
        float wheelRPM = wheelCollider.rpm;

        // Convert RPM to RPS (Revolutions Per Second)
        float wheelRPS = wheelRPM / 60f;

        // Calculate the distance traveled by the wheel in this frame
        // (Distance = Circumference * Revolutions per second * deltaTime)
        float distanceThisFrame = wheelCircumference * wheelRPS * Time.deltaTime;

        // Convert the distance from meters to kilometers
        totalDistance += distanceThisFrame / 1000f;

        // Display the total distance on the screen
        tripText.text = totalDistance.ToString("F2") + " m";
    }
}
