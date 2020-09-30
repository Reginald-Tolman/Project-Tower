using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Unit
{
    // Start is called before the first frame update
    Mech()
    {
        Health = 100;
        MoveSpeed = 0;
        Damage = 0;
        IsStationary = true;        
    }
}
