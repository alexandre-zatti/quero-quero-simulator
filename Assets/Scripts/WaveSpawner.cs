using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int numberOfEnemys;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;
    public Transform[] spawnLocations;
    public GameObject[] enemies;
    private int currentWaveNumber;
    private bool canSpawn = true;
    private float spawnTime;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        
        SpawnWave();

        GameObject[] enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
    }

    private void SpawnWave()
    {
        if (canSpawn && spawnTime < Time.time)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            
            Transform spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            
            Instantiate(enemy, spawnLocation.position, Quaternion.identity);

            currentWave.numberOfEnemys--;

            spawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.numberOfEnemys == 0)
            {
                canSpawn = false;
            }
        }
        
    }
}
