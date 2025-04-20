using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TireSO", menuName = "Car/TireSO")]
public class TireSO : ScriptableObject
{
    [Header("General Information")]
    [field: SerializeField] public string _carName;
    [field: SerializeField] public Mesh _mesh;
    [field: SerializeField] public string _description;


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

    [Header("Torque Settings")]
    [SerializeField] private AnimationCurve _powerCurve = AnimationCurve.Linear(0, 1, 1, 0.1f);
    [SerializeField] private float _torqueMultiplier;

    [Header("Raycast Settings")]
    [SerializeField] private LayerMask _groundLayer;



    public float TireMass { get { return _tireMass; } set { _tireMass = value; } }
    public float SpringStrength { get { return _springStrength; } set { _springStrength = value; } }
    public float SuspensionRestDist { get { return _suspensionRestDist; } set { _suspensionRestDist = value; } }
    public float SpringDamper { get { return _springDamper; } set { _springDamper = value; } }
    public float FrontTireGripFactor { get { return _frontTireGripFactor; } set { _frontTireGripFactor = value; } }
    public float BackTireGripFactor { get { return _backTireGripFactor; } set { _backTireGripFactor = value; } }
    public float SteerReturnSpeed { get { return _steerReturnSpeed; } set { _steerReturnSpeed = value; } }
    public float CarTopSpeed { get { return _carTopSpeed; } set { _carTopSpeed = value; }  }
    public AnimationCurve PowerCurve { get { return _powerCurve; } set { _powerCurve = value; } }
    public float TorqueMultiplier { get { return _torqueMultiplier; } set { _torqueMultiplier = value; } }
    public LayerMask GroundLayer { get { return _groundLayer; } set { _groundLayer = value; } }



}
