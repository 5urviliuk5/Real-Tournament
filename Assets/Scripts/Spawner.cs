using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> enemiesPerWave;

    [Range(0.1f, 10f)]
    public float spawnInterval = 1f;
    [Range(0.1f, 10f)]
    public float timeBetweenWaves = 5f;
    public int enemiesToSpawn;

    async void Start()
    {
        foreach (var num in enemiesPerWave)
        {
            enemiesToSpawn = num;

            while (enemiesToSpawn > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesToSpawn--;
            }

            await new WaitForSeconds(timeBetweenWaves);
        }
    }

    void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, point.rotation);
    }
}
