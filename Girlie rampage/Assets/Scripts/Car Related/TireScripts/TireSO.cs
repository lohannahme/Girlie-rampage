using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TireSO", menuName = "Car/TireSO")]
public class TireSO : ScriptableObject
{
    public Mesh mesh;

    public string description;

    public float tireMass = 0;

    [Header("Suspension Settings")]
    // Spring resistance/strength
    public float springStrength = 20000f;
    // Distance between car's rigidBody and groundLayer
    [Range(0f, 1f)]
    public float suspensionRestDist = 0.5f;
    // Damping
    [Range(0f,10f)]
    public float springDamper;

    [Header("Steering Settings")]
    //public float steeringVel;
    [Range(0f, 1f)]
    public float frontTireGripFactor;
    [Range (0f, 1f)]
    public float backTireGripFactor;
    [Range(0f, 10f)]
    public float steerReturnSpeed = 5f;

    [Header("Acceleration Settings")]
    [Range(0f, 1000f)]
    public float carTopSpeed;

    [Header("Torque Settings")]
    public AnimationCurve powerCurve = AnimationCurve.Linear(0, 1, 1, 0.1f);
    public float torqueMultiplier;

    [Header("Raycast Settings")]
    public LayerMask groundLayer;
}
