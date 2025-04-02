using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TireSO", menuName = "Car/TireSuspension")]
public class TireSO : ScriptableObject
{
    public Mesh mesh;

    [Header("SuspensionSettings")]
    // Distância de repouso
    public float suspensionRestDist = 0.5f;
    // Força da mola
    public float springStrength = 20000f;
    // Amortecimento
    [Range(0f,10f)]
    public float springDamper;
}
