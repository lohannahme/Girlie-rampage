using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChassiSO", menuName = "Gear/ChassiSO")]
public class ChassiSO : ScriptableObject
{
    [Header("General Information")]
    [field: SerializeField] private string _chassiName;
    [field: SerializeField] private Mesh _mesh;
    [field: SerializeField] private string _description;

    [Header("Steering Settings")]
    [SerializeField][Range(0f, 100f)] private float _maxSteerAngle = 50f;
    [SerializeField][Range(0f, 500f)] private float _steerSpeed = 100f;
    [SerializeField] private float _currentSteerAngle = 0f;

    public string ChassiName { get => _chassiName; set => _chassiName = value; }
    public Mesh Mesh { get => _mesh; set => _mesh = value; }
    public string Description { get => _description; set => _description = value; }
    public float MaxSteerAngle { get => _maxSteerAngle; set => _maxSteerAngle = value; }
    public float SteerSpeed { get => _steerSpeed; set => _steerSpeed = value; }
    public float CurrentSteerAngle { get => _currentSteerAngle; set => _currentSteerAngle = value; }
}
