using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    public CarController carController;
    public Transform tireTransform;
    public Rigidbody carRigidBody;
    public Transform carTransform;

    public bool isFrontTire;

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

        if(carTransform == null)
        {
            carTransform = GetComponentInParent<CarController>()?.transform;
        }
    }

    void FixedUpdate()
    {
        rayDidHit = Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay,
        carController.equippedTireSO.suspensionRestDist, carController.equippedTireSO.groundLayer);

        // SUSPENSION
        if (rayDidHit)
        {
            // World-space direction of the spring force
            Vector3 springDir = tireTransform.up;

            // World-space velocity of this tire
            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            // Calculate offset from the raycast
            float offset = carController.equippedTireSO.suspensionRestDist - tireRay.distance;

            // Calculate velocity along the spring direction
            // springDir is a unit vector, so this returns the magnitude of tireWorldVel
            // as projected onto springDir
            float vel = Vector3.Dot(springDir, tireWorldVel);

            // Calculate the magnitude of the dampened spring force
            float force = (offset * carController.equippedTireSO.springStrength) - (vel * carController.equippedTireSO.springDamper);

            // Apply the force to he position of the tire, in the suspension direction
            carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        }

        // STEERING
        if (rayDidHit)
        {
            // World-space direction perpendicular to the tire's forward axis (used for steering)
            Vector3 steeringDir = tireTransform.right;

            // Velocity of the car at the tire's position
            Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            // Lateral velocity component relative to the tire
            float lateralVel = Vector3.Dot(steeringDir, tireWorldVel);

            float desiredVelChange;
            if (isFrontTire)
            {
                // Desired change in velocity to counteract sliding, scaled by grip
                desiredVelChange = -lateralVel * carController.equippedTireSO.frontTireGripFactor;
            }
            else
            {
                desiredVelChange = -lateralVel * carController.equippedTireSO.backTireGripFactor;
            }

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

        // ACCELERATION / BRAKING
        if(rayDidHit)
        {
            // World-space direction of the acceleration/braking force
            Vector3 accelDir = tireTransform.forward;

            float accelInput = Input.GetAxis("Vertical");
            // Acceleration torque
            if (accelInput != 0.0f)
            {
                // Forward car speed (in the driving direction)
                float carSpeed = Vector3.Dot(carTransform.forward, carRigidBody.velocity);

                float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / carController.equippedTireSO.carTopSpeed);

                float availableTorque = carController.equippedTireSO.powerCurve.Evaluate(normalizedSpeed) * accelInput * carController.equippedTireSO.torqueMultiplier;

                float direction = Mathf.Sign(accelInput);

                carRigidBody.AddForceAtPosition(accelDir * availableTorque, tireTransform.position);
            }
        }
    }
}