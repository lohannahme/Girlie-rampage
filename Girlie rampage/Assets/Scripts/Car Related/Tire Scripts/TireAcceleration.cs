using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireAcceleration : TireScript
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        // ACCELERATION / BRAKING
        if (RayDidHit)
        {
            // World-space direction of the acceleration/braking force
            Vector3 accelDir = TireTransform.forward;

            

            float accelInput = Input.GetAxis("Vertical");
            // Acceleration torque
            if (accelInput != 0.0f)
            {
                // Forward car speed (in the driving direction)
                float carSpeed = Vector3.Dot(CarTransform.forward, CarRigidBody.velocity);

                float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / gearManager.equippedTireSO.CarTopSpeed);

                float availableTorque = gearManager.equippedTireSO.PowerCurve.Evaluate(normalizedSpeed) * accelInput * gearManager.equippedTireSO.TorqueMultiplier;

                float direction = Mathf.Sign(accelInput);

                CarRigidBody.AddForceAtPosition(accelDir * availableTorque, TireTransform.position);
            }
        }
    }
}
