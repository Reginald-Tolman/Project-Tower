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
    public List<GameObject> CurrentWave;    

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
    }

    public void Load(int AmountOfEnemies)
    {
        WaveSpawnTimer = 1;
        AddToWave(AmountOfEnemies);
    }

    public void AddToWave(int AmountOfEnemies)
    {
        for (int i = 0; i < AmountOfEnemies; i++)
        {
            GameObject newEnemy = UnitFactory.Create("mech");
            CurrentWave.Add(newEnemy);
        }
    } 

    public void StartNextWave()
    {
        if(CurrentWave.Count != 0)
        {            
            StartCoroutine(SpawnEnemy());
        }        
    }

    private IEnumerator SpawnEnemy()
    {
        foreach(var Enemy in CurrentWave)
        {
            if(!Enemy.GetComponent<Unit>().IsSpawned)
            {
                Enemy.GetComponent<Unit>().IsSpawned = true;
                yield return new WaitForSeconds(WaveSpawnTimer);
            }            
        }        
    }
}
