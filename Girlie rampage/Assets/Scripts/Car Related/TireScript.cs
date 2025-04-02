using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSuspension : MonoBehaviour
{
    public TireSO tireSO;
    public Transform tireTransform;
    public Rigidbody carRigidBody;

    [Header("Raycast Settings")]
    public LayerMask groundLayer;

    void Start()
    {
        if(carRigidBody == null)
        {
            carRigidBody = GetComponentInParent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        RaycastHit tireRay;
        bool rayDidHit = Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay, tireSO.suspensionRestDist, groundLayer);

        if(rayDidHit)
        {
            Vector3 springDir = tireTransform.up;

            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            float offset = tireSO.suspensionRestDist - tireRay.distance;

            float vel = Vector3.Dot(springDir, tireWorldVel);

            float force = (offset * tireSO.springStrength) - (vel * tireSO.springDamper);

            carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        }
    }
}
