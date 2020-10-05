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
        MoveSpeed = 500;
        Damage = 5;
        IsStationary = false;        
        IsSpawned = false;
    }

    public override Unit Clone()
    {
        return (Mech)this.MemberwiseClone();
    }

    public override void Initialized()
    {
        Material = (Material)Resources.Load("Basic Mech");

        gameObject.GetComponent<MeshRenderer>().material = Material;
    }
}
