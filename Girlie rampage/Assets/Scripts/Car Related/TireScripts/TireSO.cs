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
    public float tireGripFactor;

    [Header("Raycast Settings")]
    public LayerMask groundLayer;
}
