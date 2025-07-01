using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CarPartSO", menuName = "Customization/CarPartSO", order = 0)]
public class CarPartSO : ScriptableObject
{
    [SerializeField] private PartSlot _slot;
    [SerializeField] private PartType _type;
    [SerializeField] private PartStyle _style;
    [SerializeField] private PartType[] _incompatibility;
    [SerializeField] private CarAttribute[] _attributes;

    public PartSlot Slot => _slot;
    public PartType Type => _type;
    public PartStyle Style => _style;
    public PartType[] Incompatibility => _incompatibility;

    public float GetAttribute(string key)
    {
        if (_attributes.TryGetValue(key, out float value))
        {
            return value;
        }
        throw new Exception($"Invalid Key. this Car Part dont have a value for \"{key}\".");
    }
}

public enum PartSlot
{
    TIRE,
    CHASSI
}
public enum PartType
{
    LIGHT,
    MEDIUM,
    HEAVY
}

public enum PartStyle
{
    DEFAULT
}