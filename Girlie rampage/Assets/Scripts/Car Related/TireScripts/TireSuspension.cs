using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSuspension : TireClass
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (rayDidHit)
        {
            // World-space direction of the spring force
            Vector3 springDir = tireTransform.up;

            // World-space velocity of this tire
            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            // Calculate offset from the raycast
            float offset = carScript.equippedTireSO.suspensionRestDist - tireRay.distance;

            // Calculate velocity along the spring direction
            // springDir is a unit vector, so this returns the magnitude of tireWorldVel
            // as projected onto springDir
            float vel = Vector3.Dot(springDir, tireWorldVel);

            // Calculate the magnitude of the dampened spring force
            float force = (offset * carScript.equippedTireSO.springStrength) - (vel * carScript.equippedTireSO.springDamper);

            // Apply the force to he position of the tire, in the suspension direction
            carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        }
    }
}
