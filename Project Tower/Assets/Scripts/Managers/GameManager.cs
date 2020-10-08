using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        WaveManager.Instance.StartNextWave(10);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();
        DestoryFlaggedUnits();
    }

    private void DestoryFlaggedUnits()
    {
        if(WaveManager.Instance.RemoveFromWave.Count > 0)
        {
            foreach(var go in WaveManager.Instance.RemoveFromWave)
            {
                WaveManager.Instance.CurrentWave.Remove(go);
                Destroy(go);
            }
            WaveManager.Instance.RemoveFromWave.Clear();
        }
    }

    private void MoveEnemies()
    {
        foreach(var enemy in WaveManager.Instance.CurrentWave)
        {
            enemy.GetComponent<Unit>().Move();
        }
    }
}
