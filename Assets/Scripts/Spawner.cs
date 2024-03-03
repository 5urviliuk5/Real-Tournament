using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;

    async void Start()
    {
        await new WaitForSeconds(2f);
        Spawn();
    }

    void Spawn()
    {
        while (true)
        {
            var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(prefab, point.position, point.rotation);
        }
    }
}
