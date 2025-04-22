using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public TireSO equippedTireSO;
    public ChassiSO equippedChassiSO;

    [Header("Wheel Transforms")]
    public TireScript frontalTire1;
    public TireScript frontalTire2;

    private List<TireScript> _firstTwoTires = new List<TireScript>();
    void Awake()
    {

        TireScript[] allTiresComponents = GetComponentsInChildren<TireScript>();

        HashSet<GameObject> uniqueGameObjects = new HashSet<GameObject>();

        // Automatically finds the first 2 tires (game objects with TireScript scripts) and
        // set them as frontal tires
        foreach (TireScript tire in allTiresComponents)
        {
            if (!uniqueGameObjects.Contains(tire.gameObject))
            {
                uniqueGameObjects.Add(tire.gameObject);
                _firstTwoTires.Add(tire);
            }

            if (_firstTwoTires.Count == 2)
            {
                frontalTire1 = _firstTwoTires[0];
                frontalTire2 = _firstTwoTires[1];

                // Instantly sets them as front tires
                // This will change which gripFactor value the TireScript will use when
                // calculating these object's physics
                frontalTire1.IsFrontTire = true;
                frontalTire2.IsFrontTire = true;

                if (_firstTwoTires.Count < 2)
                {
                    Debug.LogError("Insuficient tires in PlayerCar. Please, add at least 2 as children in the 'Tires' game object. Those will be identified as frontal tires.");
                }
            }
        }
    }
}