using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class UnitFactory
{
    private static Dictionary<string, Type> unitTypesByName;
    private static bool isInitialized => unitTypesByName != null;

    public static void InitializeUnitFactory()
    {
        if(isInitialized)
        {
            return;
        }
        //This will find all the classes that inherit Unit ->> fucking amazing
        // The where clause makes sure its a class, its not abstract and its a sub of unit
        var unitTypes = Assembly.GetAssembly(typeof(Unit)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Unit)));
        unitTypesByName = new Dictionary<string, Type>();
        foreach(var type in unitTypes)
        {
            //There is no good way to get the data of the class, so we have to instansiate it once to pull the name, this will be all done in the pre-load
            var tempUnit = Activator.CreateInstance(type) as Unit;
            unitTypesByName.Add(tempUnit.UnitType, type);
        }
    }
    //Make and overload method for parsing in the unit enum instead
    public static GameObject Create(string UnitType)
    {      
        InitializeUnitFactory();

        if (unitTypesByName.ContainsKey(UnitType))
        {
            Type type = unitTypesByName[UnitType];
            var unit = Activator.CreateInstance(type) as Unit;
            GameObject newUnit = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newUnit.AddComponent(type);
            newUnit.GetComponent<Unit>().Initialized();
            
            return newUnit;
        }

        return null;
    }
}
