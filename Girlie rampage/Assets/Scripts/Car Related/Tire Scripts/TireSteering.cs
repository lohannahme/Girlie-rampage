using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSteering : TireScript
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // STEERING
        if (RayDidHit)
        {
            // World-space direction perpendicular to the tire's forward axis (used for steering)
            Vector3 steeringDir = TireTransform.right;

            // Velocity of the car at the tire's position
            Vector3 tireWorldVel = CarRigidBody.GetPointVelocity(TireTransform.position);

            // Lateral velocity component relative to the tire
            float lateralVel = Vector3.Dot(steeringDir, tireWorldVel);

            float desiredVelChange;
            if (IsFrontTire)
            {
                // Desired change in velocity to counteract sliding, scaled by grip
                desiredVelChange = -lateralVel * gearManager.equippedTireSO.FrontTireGripFactor;
            }
            else
            {
                desiredVelChange = -lateralVel * gearManager.equippedTireSO.BackTireGripFactor;
            }

            // Required acceleration to achieve the velocity change in one physics step
            float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

            // Calculated force to apply to the tire
            Vector3 force = steeringDir * gearManager.equippedTireSO.TireMass * desiredAccel;

            // Clamp the force to avoid unrealistic steering behavior
            float maxForce = 500f;
            force = Vector3.ClampMagnitude(force, Mathf.Abs(lateralVel) * maxForce);

            // Apply force only if lateral velocity is significant
            if (Mathf.Abs(lateralVel) > 0.01f)
                CarRigidBody.AddForceAtPosition(force, TireTransform.position);
        }
    }
}
