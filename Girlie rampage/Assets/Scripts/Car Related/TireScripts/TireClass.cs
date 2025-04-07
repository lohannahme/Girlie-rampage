using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireClass : MonoBehaviour
{
    public CarController carController;
    public Transform tireTransform;
    public Rigidbody carRigidBody;

    protected bool rayDidHit;
    protected RaycastHit tireRay;

    protected virtual void Start()
    {
        if (carRigidBody == null)
        {
            carRigidBody = GetComponentInParent<Rigidbody>();
        }

        if (carController == null)
        {
            carController = GetComponentInParent<CarController>();
        }
    }

    protected virtual void FixedUpdate()
    {
        rayDidHit = Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay,
        carController.equippedTireSO.suspensionRestDist, carController.equippedTireSO.groundLayer);
    }
}
