using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public TireSO equippedTireSO;

    [Header("Wheel Transforms")]
    public TireScript frontalTire1;
    public TireScript frontalTire2;

    [Header("Steering Settings")]
    [Range(0f, 100f)]
    public float maxSteerAngle = 50f;
    [Range(0f, 500f)]
    public float steerSpeed = 100f;

    private float _currentSteerAngle = 0f;

    public float CurrentSteerAngle => _currentSteerAngle;


    private List<TireScript> _firstTwoTires = new List<TireScript> ();
    void Awake()
    {
        
        TireScript[] allTiresComponents = GetComponentsInChildren<TireScript>();

        HashSet<GameObject> uniqueGameObjects = new HashSet<GameObject>();

        // Automatically finds the first 2 tires (game objects with TireScript scripts) and
        // set them as frontal tires
        foreach (TireScript tire in allTiresComponents)
        {
            if(!uniqueGameObjects.Contains(tire.gameObject))
            {
                uniqueGameObjects.Add(tire.gameObject);
                _firstTwoTires.Add(tire);
            }
            
            if(_firstTwoTires.Count == 2)
            {
                frontalTire1 = _firstTwoTires[0];
                frontalTire2 = _firstTwoTires[1];

                // Instantly sets them as front tires
                // This will change which gripFactor value the TireScript will use when
                // calculating these object's physics
                frontalTire1.isFrontTire = true;
                frontalTire2.isFrontTire = true;
            }
        }

        if(_firstTwoTires.Count < 2)
        {
            Debug.LogError("Insuficient tires in PlayerCar. Please, add at least 2 as children in the 'Tires' game object. Those will be identified as frontal tires.");
        }
    }

    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        float steerInput = Input.GetAxis("Horizontal");

        _currentSteerAngle += steerInput * steerSpeed * Time.deltaTime;
        _currentSteerAngle = Mathf.Clamp(_currentSteerAngle, -maxSteerAngle, maxSteerAngle);

        if (frontalTire1 != null && frontalTire1.tireTransform != null)
        {
            frontalTire1.tireTransform.localRotation = Quaternion.Euler(0f, _currentSteerAngle, 0f);
        }

        if (frontalTire2 != null && frontalTire2.tireTransform != null)
        {
            frontalTire2.tireTransform.localRotation = Quaternion.Euler(0f, _currentSteerAngle, 0f);
        }

        // Resets the steering angle when no input is detected
        if(Input.GetAxis("Horizontal") == 0f)
        {
            _currentSteerAngle = 0f;
            //_currentSteerAngle = Mathf.Lerp(_currentSteerAngle, 0f, Time.deltaTime * equippedTireSO.steerReturnSpeed);
        }
    }
}
