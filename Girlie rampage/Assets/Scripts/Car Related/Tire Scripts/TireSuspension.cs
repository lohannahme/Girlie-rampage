using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSuspension : TireScript
{

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        // SUSPENSION
        if (RayDidHit)
        {
            // World-space direction of the spring force
            Vector3 springDir = TireTransform.up;

            // World-space velocity of this tire
            Vector3 tireWorldVel = CarRigidBody.GetPointVelocity(TireTransform.position);

            // Calculate offset from the raycast
            float offset = gearManager.equippedTireSO.SuspensionRestDist -_tireRay.distance;

            // Calculate velocity along the spring direction
            // springDir is a unit vector, so this returns the magnitude of tireWorldVel
            // as projected onto springDir
            float vel = Vector3.Dot(springDir, tireWorldVel);

            // Calculate the magnitude of the dampened spring force
            float force = (offset * gearManager.equippedTireSO.SpringStrength) - (vel * gearManager.equippedTireSO.SpringDamper);

            // Apply the force to he position of the tire, in the suspension direction
            CarRigidBody.AddForceAtPosition(springDir * force, TireTransform.position);
        }
    }
}
