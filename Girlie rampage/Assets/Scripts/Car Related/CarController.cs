using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public TireSO equippedTireSO;

    [Header("Wheel Transforms")]
    public Transform leftWheel;
    public Transform rightWheel;

    [Header("Steering Settings")]
    public float maxSteerAngle = 30f;
    public float steerSpeed = 100f;

    private float currentSteerAngle = 0f;

    public float CurrentSteerAngle => currentSteerAngle; // Allows access from other scripts

    void Update()
    {
        // Get player input (-1 for A, 1 for D)
        float steerInput = Input.GetAxis("Horizontal");

        // Calculate the new angle based on player input
        currentSteerAngle += steerInput * steerSpeed * Time.deltaTime;

        // Clamp the steering angle within the allowed range
        currentSteerAngle = Mathf.Clamp(currentSteerAngle, -maxSteerAngle, maxSteerAngle);

        // Apply rotation to both wheels
        leftWheel.localRotation = Quaternion.Euler(0f, currentSteerAngle, 0f);
        rightWheel.localRotation = Quaternion.Euler(0f, currentSteerAngle, 0f);
    }
}
