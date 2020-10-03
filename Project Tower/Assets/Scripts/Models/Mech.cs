using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Unit
{
    // Start is called before the first frame update
    public Mech()
    {
        Health = 100;
        MoveSpeed = 500;
        Damage = 5;
        IsStationary = false;        
        IsSpawned = false;
    }
}
