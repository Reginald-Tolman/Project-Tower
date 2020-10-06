using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
    public override string UnitType => "tower";
    public Tower()
    {
        Health = 100;
        BaseMoveSpeed = 0;
        AddedFlatMoveSpeed = 0;
        Damage = 0;
        IsStationary = true;
        IsSpawned = false;        
    }

    public override void Initialized()
    {
        
    }
}
