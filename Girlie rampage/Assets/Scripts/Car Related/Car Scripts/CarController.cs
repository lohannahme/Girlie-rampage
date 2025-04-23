using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("GearsManager")]
    [SerializeField] GearManager gearManager;

    [SerializeField] Rigidbody rb;
    

    void Update()
    {
        Steer();
        ResetRotation();
    }

    public void Steer()
    {
        float steerInput = Input.GetAxis("Horizontal");

        gearManager.equippedChassiSO.CurrentSteerAngle += steerInput * gearManager.equippedChassiSO.SteerSpeed * Time.deltaTime;
        gearManager.equippedChassiSO.CurrentSteerAngle = Mathf.Clamp(gearManager.equippedChassiSO.CurrentSteerAngle, -gearManager.equippedChassiSO.MaxSteerAngle, gearManager.equippedChassiSO.MaxSteerAngle);

        if (gearManager.frontalTire1 != null && gearManager.frontalTire1.TireTransform != null)
        {
            gearManager.frontalTire1.TireTransform.localRotation = Quaternion.Euler(0f, gearManager.equippedChassiSO.CurrentSteerAngle, 0f);
        }

        if (gearManager.frontalTire2 != null && gearManager.frontalTire2.TireTransform != null)
        {
            gearManager.frontalTire2.TireTransform.localRotation = Quaternion.Euler(0f, gearManager.equippedChassiSO.CurrentSteerAngle, 0f);
        }

        // Resets the steering angle when no input is detected
        if(Input.GetAxis("Horizontal") == 0f)
        {
            // Smoothes out steering reset
            gearManager.equippedChassiSO.CurrentSteerAngle = Mathf.Lerp(gearManager.equippedChassiSO.CurrentSteerAngle, 0f, Time.deltaTime * gearManager.equippedTireSO.SteerReturnSpeed);
        }
    }

    public void Brake()
    {
        // Direção oposta à velocidade atual
        Vector3 brakeForce = -rb.velocity.normalized * gearManager.equippedTireSO.BrakeForce;

        // Aplica a força de frenagem
        rb.AddForce(brakeForce, ForceMode.Acceleration);
    }

    public void ResetRotation()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
            transform.position = new Vector3(transform.position.x, 2.4f, transform.position.z);
        }
    }
}
