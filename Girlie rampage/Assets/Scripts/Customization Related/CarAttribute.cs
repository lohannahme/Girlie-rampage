using System;
using UnityEngine;

[Serializable]
public class CarAttribute
{
    [SerializeField] private string _key;
    [SerializeField] bool _useCurve;
    [SerializeField] private float _value;
    [SerializeField] private AnimationCurve _curve;

    public float GetValue(float curveValue = 0)
    {
        if (_useCurve)
        {
            return _curve.Evaluate(curveValue);
        }
        return Value;
    }

    public string Key => _key;
    public float Value => _value;
}