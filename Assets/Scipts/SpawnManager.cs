using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;

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
            AddPowerup(1);
        }
    }

    private void AddEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
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
            int index = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[index], GenerateSpawnPosition(), powerupPrefab[index].transform.rotation);
        }
    }
    
}
