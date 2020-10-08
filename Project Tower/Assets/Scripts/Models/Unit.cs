using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // Specifies the type of unit.. Used in factory to create units
    public GameObject go;
    public abstract string UnitType { get; }
    public int Health { get => health; set => health = value; }
    public float BaseMoveSpeed;
    public int AddedFlatMoveSpeed;
    public int Damage { get => damage; set => damage = value; }
    public bool IsStationary { get => isStationary; set => isStationary = value; }
    public bool IsSpawned { get => isSpawned; set => isSpawned = value; }
    public Mesh UnitMesh { get => unitMesh; set => unitMesh = value; }
    public Material Material { get => material; set => material = value; }
    private int health;
    private int moveSpeed;
    private int damage;
    private bool isStationary;
    [SerializeField]
    private bool isSpawned;
    private Mesh unitMesh;
    private Material material;
    private Waypoint CurrentWaypoint;
    private bool toBeDestoryed = false;
    public abstract void Initialized();

    public virtual void Move()
    {
        // transform.position += new Vector3(Random.RandomRange(-4, 4) * Time.deltaTime, Random.RandomRange(-4, 4) * Time.deltaTime, Random.RandomRange(-4, 4) * Time.deltaTime);
        
        //Grab first waypoint if unit has no waypoint
        if(IsSpawned)
        {
            if(CurrentWaypoint == null)
                CurrentWaypoint = WaveManager.Instance.Waypoints[0];
            
            MoveToWaypoint();

            if(toBeDestoryed)
            {
                DestoryUnit();
            }
        }
    }

    public virtual void FindNextWaypoint()
    {
        int currentIndex = WaveManager.Instance.Waypoints.FindIndex( w => w == CurrentWaypoint);
        if (!(currentIndex + 1 > WaveManager.Instance.Waypoints.Count - 1))
        {
            CurrentWaypoint = WaveManager.Instance.Waypoints[currentIndex + 1];
        }
        else
        {
            toBeDestoryed = true;
        }
    }

    public virtual void MoveToWaypoint()
    {      
        if(transform.position == CurrentWaypoint.Position)
        {
            FindNextWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.Position, (BaseMoveSpeed +  AddedFlatMoveSpeed) * Time.deltaTime);
    }

    public virtual void DestoryUnit()
    {
            WaveManager.Instance.RemoveFromWave.Add(gameObject);
    }

}
