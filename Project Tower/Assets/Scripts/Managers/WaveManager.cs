using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static WaveManager instance;
    public static WaveManager Instance { get { return instance; } }
    private static readonly object padlock = new object();

    public int CurrentWaveNumber;
    public int WaveSpawnTimer;
    public List<Waypoint> Waypoints;
    public List<GameObject> CurrentWave;
    public List<GameObject> RemoveFromWave; 

    private float timeStamp;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        GenerateWaypoints();
    }

    private void GenerateWaypoints()
    {
        for(int i = 0; i < 4; i++)
        {
            Waypoint newWaypoint = new Waypoint();
            newWaypoint.Position = new Vector3(UnityEngine.Random.Range(-10, 10) * i, UnityEngine.Random.Range(-10, 10) * i, UnityEngine.Random.Range(-10, 10) * i);
            Waypoints.Add(newWaypoint);
        }
    }

    public void Load(int AmountOfEnemies)
    {
        WaveSpawnTimer = 1;
    }

    public void StartNextWave(int AmountOfEnemies)
    {
        if(AmountOfEnemies != 0)
        {            
            StartCoroutine(SpawnWave(AmountOfEnemies));
        }        
    }

    private IEnumerator SpawnWave(int AmountOfEnemies)
    {
        for (int i = 0; i < AmountOfEnemies; i++)
        {
            GameObject newEnemy = UnitFactory.Create("mech");
            newEnemy.GetComponent<Unit>().IsSpawned = true;
            CurrentWave.Add(newEnemy);
            yield return new WaitForSeconds(WaveSpawnTimer + 1);             
        }        
    }

    private void SpawnUnit()
    {
        UnitFactory.Create("mech");
    }

    public void RemoveUnitFromCurrentWave(GameObject gameObject)
    {

    }
}
