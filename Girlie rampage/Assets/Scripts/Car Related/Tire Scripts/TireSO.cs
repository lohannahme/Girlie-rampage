using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TireSO", menuName = "Gear/TireSO")]
public class TireSO : ScriptableObject
{
    [Header("General Information")]
    [field: SerializeField] private string _tireName;
    [field: SerializeField] private Mesh _mesh;
    [field: SerializeField] private string _description;


    [SerializeField] private float _tireMass = 0f;

    [Header("Suspension Settings")]
    [SerializeField] private float _springStrength = 20000f;
    // Distance between car's rigidBody and groundLayer
    [SerializeField][Range(0f, 1f)] private float _suspensionRestDist = 0.5f;

    // Damping
    [Range(0f, 10f)]
    [SerializeField] private float _springDamper;

    // Steering
    [Header("Steering Settings")]
    //public float steeringVel;
    [SerializeField][Range(0f, 1f)] private float _frontTireGripFactor;
    [SerializeField][Range(0f, 1f)] private float _backTireGripFactor;
    [SerializeField][Range(0f, 10f)] private float _steerReturnSpeed = 5f;

    [Header("Acceleration Settings")]
    [SerializeField][Range(0f, 1000f)] private float _carTopSpeed;

    [Header("Brake Settings")]
    [SerializeField][Range(0f, 1000f)] private float _brakeForce;

    [Header("Torque Settings")]
    [SerializeField] private AnimationCurve _powerCurve = AnimationCurve.Linear(0, 1, 1, 0.1f);
    [SerializeField] private float _torqueMultiplier;

    [Header("Raycast Settings")]
    [SerializeField] private LayerMask _groundLayer;

    public string TireName { get => _tireName; set => _tireName = value; }
    public Mesh Mesh { get => _mesh; set => _mesh = value; }
    public string Description { get => _description; set => _description = value; }

    public float TireMass { get { return _tireMass; } }
    public float SpringStrength { get { return _springStrength; } }
    public float SuspensionRestDist { get { return _suspensionRestDist; } }
    public float SpringDamper { get { return _springDamper; } }
    public float FrontTireGripFactor { get { return _frontTireGripFactor; } }
    public float BackTireGripFactor { get { return _backTireGripFactor; } }
    public float SteerReturnSpeed { get { return _steerReturnSpeed; } }
    public float CarTopSpeed { get { return _carTopSpeed; } }
    public AnimationCurve PowerCurve { get { return _powerCurve; } }
    public float TorqueMultiplier { get { return _torqueMultiplier; } }
    public float BrakeForce { get { return _brakeForce; } }
    public LayerMask GroundLayer { get { return _groundLayer; } }
}
