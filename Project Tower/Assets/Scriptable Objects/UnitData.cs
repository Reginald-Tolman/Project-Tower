using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Data")]
public class UnitData : ScriptableObject
{
    public int Health;
    public int MoveSpeed;
    public int Damage;
    public bool IsStationary;
    public bool IsSpawned;
    public string UnitType;
}
