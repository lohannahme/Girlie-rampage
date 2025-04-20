using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("GearsManager")]
    [SerializeField] GearManager gearManager;

    [Header("Steering Settings")]
    
    [Range(0f, 100f)]
    [SerializeField] float _maxSteerAngle = 50f;
    private float MaxSteerAngle
    {
        get => _maxSteerAngle;
        set => _maxSteerAngle = value;
    }

    [Range(0f, 500f)]
    [SerializeField] float _steerSpeed = 100f;
    private float SteerSpeed
    {
        get => _steerSpeed;
        set => _steerSpeed = value;
    }

    private float _currentSteerAngle = 0f;
    private float CurrentSteerAngle
    {
        get => _currentSteerAngle;
        set => _currentSteerAngle = value;
    }


    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        float steerInput = Input.GetAxis("Horizontal");

        CurrentSteerAngle += steerInput * SteerSpeed * Time.deltaTime;
        CurrentSteerAngle = Mathf.Clamp(CurrentSteerAngle, -MaxSteerAngle, MaxSteerAngle);

        if (gearManager.frontalTire1 != null && gearManager.frontalTire1.TireTransform != null)
        {
            gearManager.frontalTire1.TireTransform.localRotation = Quaternion.Euler(0f, CurrentSteerAngle, 0f);
        }

        if (gearManager.frontalTire2 != null && gearManager.frontalTire2.TireTransform != null)
        {
            gearManager.frontalTire2.TireTransform.localRotation = Quaternion.Euler(0f, CurrentSteerAngle, 0f);
        }

        // Resets the steering angle when no input is detected
        if(Input.GetAxis("Horizontal") == 0f)
        {
            // Smoothes out steering reset
            CurrentSteerAngle = Mathf.Lerp(CurrentSteerAngle, 0f, Time.deltaTime * gearManager.equippedTireSO.SteerReturnSpeed);
        }
    }
}
