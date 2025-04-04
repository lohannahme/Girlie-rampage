using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSteering : TireClass
{

    [Header("Steering Settings")]
    public float steeringVel;
    public float tireGripFactor;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (rayDidHit)
        {
            // World-space direction of the spring force
            Vector3 steeringDir = tireTransform.right;

            // World-space velocity of the suspension
            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            // steeringDir is a unit vector, so this returns the magnitude of tireWorldVel
            float desiredVelChange = -steeringVel * tireGripFactor;

            // Turn change in velocity into an acceleration
            // Produces the acceleration necessary to change the velocity by desiredVelChange
            // in 1 physics step
            float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

            // Force = Mass * Acceleration
            carRigidBody.AddForceAtPosition(steeringDir * tireMass * desiredAccel,
                tireTransform.position);
        }
    }

}
