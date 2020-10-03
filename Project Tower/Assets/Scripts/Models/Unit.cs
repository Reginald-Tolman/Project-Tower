using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // Specifies the type of unit.. Used in factory to create units
    public abstract string UnitType { get; }
    public int Health { get => health; set => health = value; }
    public int MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public bool IsStationary { get => isStationary; set => isStationary = value; }
    public bool IsSpawned { get => isSpawned; set => isSpawned = value; }
    public Mesh UnitMesh { get => unitMesh; set => unitMesh = value; }
    public MeshFilter MeshFilter { get => meshFilter; set => meshFilter = value; }
    public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }
    public MeshRenderer MeshRenderer { get => meshRenderer; set => meshRenderer = value; }
    public Material Material { get => material; set => material = value; }
    private int health;
    private int moveSpeed;
    private int damage;
    private bool isStationary;
    private bool isSpawned;
    private Mesh unitMesh;
    private MeshFilter meshFilter;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;
    private Material material;

    public abstract void Initialized();
    public abstract Unit Clone();
}
