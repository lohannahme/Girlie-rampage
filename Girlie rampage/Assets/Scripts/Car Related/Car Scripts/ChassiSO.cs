using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChassiSO", menuName = "Gear/ChassiSO")]
public class ChassiSO : ScriptableObject
{
    [Header("General Information")]
    [field: SerializeField] public string _chassiName;
    [field: SerializeField] public Mesh _mesh;
    [field: SerializeField] public string _description;

    [Header("Steering Settings")]
    [SerializeField][Range(0f, 100f)] float _maxSteerAngle = 50f;
    public float MaxSteerAngle
    {
        get => _maxSteerAngle;
        set => _maxSteerAngle = value;
    }

    [Range(0f, 500f)]
    [SerializeField] float _steerSpeed = 100f;
    public float SteerSpeed
    {
        get => _steerSpeed;
        set => _steerSpeed = value;
    }

    [SerializeField] private float _currentSteerAngle = 0f;

    public float CurrentSteerAngle
    {
        get => _currentSteerAngle;
        set => _currentSteerAngle = value;
    }
}
