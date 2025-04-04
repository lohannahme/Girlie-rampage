using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireClass : MonoBehaviour
{
    public CarController carScript;
    public Transform tireTransform;
    public Rigidbody carRigidBody;
    public float tireMass = 2;

    [Header("Raycast Settings")]
    public LayerMask groundLayer;

    protected bool rayDidHit;
    protected RaycastHit tireRay;

    protected virtual void Start()
    {
        if (carRigidBody == null)
        {
            carRigidBody = GetComponentInParent<Rigidbody>();
        }

        if (carScript == null)
        {
            carScript = GetComponentInParent<CarController>();
        }
    }

    protected virtual void FixedUpdate()
    {
        rayDidHit = Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay,
        carScript.equippedTireSO.suspensionRestDist, groundLayer);
    }
}
