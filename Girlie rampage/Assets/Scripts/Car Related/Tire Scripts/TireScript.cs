using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    CarController carController;
    public GearManager gearManager;

    [Header("Car Elements")]
    [SerializeField] private Transform _tireTransform;
    [SerializeField] private Rigidbody _carRigidBody;
    [SerializeField] private Transform _carTransform;
    [SerializeField] private bool _isFrontTire;
    [SerializeField] private bool _rayDidHit;
    [SerializeField] protected RaycastHit _tireRay;

    // Encapsulation
    public Transform TireTransform { get { return _tireTransform; } set { _tireTransform = value; } }
    public Rigidbody CarRigidBody { get { return _carRigidBody; } set { _carRigidBody = value; } }
    public Transform CarTransform { get { return _carTransform; } set {  _carTransform = value; } }   
    public bool IsFrontTire { get { return _isFrontTire; } set { _isFrontTire = value; } }
    public bool RayDidHit { get { return _rayDidHit; } set { _rayDidHit = value; } }
    // public RaycastHit TireRay { get { return _tireRay; } set { _tireRay = value; } }

    protected virtual void Start()
    {
        if( TireTransform == null)
        {
            TireTransform = GetComponent<Transform>();
        }
        if (_carRigidBody == null)
        {
            _carRigidBody = GetComponentInParent<Rigidbody>();
        }

        if (carController == null)
        {
            carController = GetComponentInParent<CarController>();
        }

        if(gearManager == null)
        {
            gearManager = GetComponentInParent<GearManager>();
        }

        if(_carTransform == null)
        {
            _carTransform = GetComponentInParent<CarController>()?.transform;
        }
    }

    public virtual void FixedUpdate()
    {
        RayDidHit = Physics.Raycast(TireTransform.position, -TireTransform.up, out _tireRay,
        gearManager.equippedTireSO.SuspensionRestDist, gearManager.equippedTireSO.GroundLayer);
    }
}