using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public TireSO equippedTireSO;

    [Header("Wheel Transforms")]
    public TireClass leftWheel;
    public TireClass rightWheel;

    [Header("Steering Settings")]
    [Range(0f, 100f)]
    public float maxSteerAngle = 50f;
    [Range(0f, 500f)]
    public float steerSpeed = 100f;

    private float _currentSteerAngle = 0f;

    public float CurrentSteerAngle => _currentSteerAngle;

    void Update()
    {
        float steerInput = Input.GetAxis("Horizontal");

        _currentSteerAngle += steerInput * steerSpeed * Time.deltaTime;
        _currentSteerAngle = Mathf.Clamp(_currentSteerAngle, -maxSteerAngle, maxSteerAngle);

        if (leftWheel != null && leftWheel.tireTransform != null)
        {
            leftWheel.tireTransform.localRotation = Quaternion.Euler(0f, _currentSteerAngle, 0f);
        }

        if (rightWheel != null && rightWheel.tireTransform != null)
        {
            rightWheel.tireTransform.localRotation = Quaternion.Euler(0f, _currentSteerAngle, 0f);
        }
    }
}
