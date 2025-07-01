using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CarConfigSO", menuName = "Customization/CarConfigSO", order = 0)]
public class CarConfigSO : ScriptableObject
{
    [SerializeField] private CarPartSO _defaultTires;
    [SerializeField] private CarPartSO _defaultChassi;

    private Dictionary<PartSlot, CarPartSO> _parts;

    public Action<CarPartSO> onEquipPart;

    public Dictionary<PartSlot, CarPartSO> Parts { get => _parts; }

    private void OnValidate()
    {
        if (_defaultTires != null)
        {
            if (_defaultTires.Slot == PartSlot.TIRE)
            {
                _defaultTires = null;
                Debug.LogError("Default Chassi must be tire type.", this);
            }
        }

        if (_defaultChassi != null)
        {
            if (_defaultChassi.Slot == PartSlot.CHASSI)
            {
                _defaultChassi = null;
                Debug.LogError("Default Chassi must be chassi type.", this);
            }
        }
    }

    public void Initialize()
    {
        _parts.Add(PartSlot.TIRE, _defaultTires);
        _parts.Add(PartSlot.CHASSI, _defaultChassi);
    }

    public bool Equip(CarPartSO part)
    {
        if (part.Slot == PartSlot.CHASSI)
        {
            if (!CanEquip(part))
            {
                Debug.Log("Incompatible part");
                return false;
            }
        }

        _parts[part.Slot] = part;
        onEquipPart?.Invoke(part);
        return true;
    }

    public bool CanEquip(CarPartSO part)
    {
        return _parts.Values.ToArray().IsCompatible(part);
    }

    public void Unequip(CarPartSO part)
    {
        if (_parts.ContainsValue(part))
        {
            _parts[part.Slot] = null;
            onEquipPart?.Invoke(part);
        }
    }

    //TODO: Save Load functions
}