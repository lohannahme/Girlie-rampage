using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TireSO", menuName = "Car/TireSuspension")]
public class TireSO : ScriptableObject
{
    public Mesh mesh;

    [Header("Suspension Settings")]
    // Spring resistance/strength
    public float springStrength = 20000f;
    // Distance between car's rigidBody and groundLayer
    [Range(0f, 1f)]
    public float suspensionRestDist = 0.5f;
    // Damping
    [Range(0f,10f)]
    public float springDamper;
}
