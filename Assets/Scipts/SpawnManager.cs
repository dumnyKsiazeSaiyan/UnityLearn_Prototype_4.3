using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject bossPrefab;

    private int bossRound = 5;
    private float spawnRang = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    private void Start()
    {
        AddEnemy(waveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            
            waveNumber++;
            AddEnemy(waveNumber);
            if(waveNumber % bossRound == 0)
            {
                Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
            }
            AddPowerup(1);
        }
    }

    private void AddEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], GenerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRang, spawnRang);
        float spawnPosZ = Random.Range(-spawnRang, spawnRang);
        Vector3 randomPos = new(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    private void AddPowerup(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[index], GenerateSpawnPosition(), powerupPrefabs[index].transform.rotation);
        }
    }
    
}
