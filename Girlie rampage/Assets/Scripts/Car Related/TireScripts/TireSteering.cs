using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSteering : TireClass
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (rayDidHit)
        {
            // World-space direction perpendicular to the tire's forward axis (used for steering)
            Vector3 steeringDir = tireTransform.right;

            // Velocity of the car at the tire's position
            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            // Lateral velocity component relative to the tire
            float lateralVel = Vector3.Dot(steeringDir, tireWorldVel);

            // Desired change in velocity to counteract sliding, scaled by grip
            float desiredVelChange = -lateralVel * carController.equippedTireSO.tireGripFactor;

            // Required acceleration to achieve the velocity change in one physics step
            float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

            // Calculated force to apply to the tire
            Vector3 force = steeringDir * carController.equippedTireSO.tireMass * desiredAccel;

            // Clamp the force to avoid unrealistic steering behavior
            float maxForce = 500f;
            force = Vector3.ClampMagnitude(force, Mathf.Abs(lateralVel) * maxForce);

            // Apply force only if lateral velocity is significant
            if (Mathf.Abs(lateralVel) > 0.01f)
                carRigidBody.AddForceAtPosition(force, tireTransform.position);
        }
    }
}
