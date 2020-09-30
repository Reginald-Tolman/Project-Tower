using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
    // Start is called before the first frame update
    Tower()
    {
        Health = 100;
        MoveSpeed = 0;
        IsStationary = true;        
    }
}
