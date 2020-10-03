using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
    public override string UnitType => "tower";
    public Tower()
    {
        Health = 100;
        MoveSpeed = 0;
        Damage = 0;
        IsStationary = true;
        IsSpawned = false;        
    }

    public override Unit Clone()
    {
        return (Tower)this.MemberwiseClone();
    }

    public override void Initialized()
    {
        
    }
}
