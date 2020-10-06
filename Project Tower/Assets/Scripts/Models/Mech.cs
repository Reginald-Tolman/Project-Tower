using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Unit
{
    // Start is called before the first frame update
    //=> is the same as { get { return "mech"}}
    public override string UnitType => "mech";
    public Mech()
    {
        Health = 100;
        BaseMoveSpeed = 500;
        AddedFlatMoveSpeed = 0;
        Damage = 5;
        IsStationary = false;        
        IsSpawned = false;
    }

    public override void Initialized()
    {
        Material = (Material)Resources.Load("Basic Mech");
        gameObject.GetComponent<MeshRenderer>().material = Material;
    }
}
