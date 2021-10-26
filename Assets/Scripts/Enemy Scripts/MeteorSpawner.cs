using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minSpawnInterval = 4.0f, maxSpawnInterval = 10.0f;
    private float interval;
    [SerializeField] private int minSpawnNumber = 1, maxSpawnNumber = 5;
    private int randSpawnNumber;
    private Vector3 randSpawnPosition;

    void SpawnMeteor()
    {
        interval = Random.Range(minSpawnInterval, maxSpawnInterval) + Time.time;
        randSpawnNumber = Random.Range(minSpawnNumber, maxSpawnNumber);
        for (int i = 0; i < randSpawnNumber; i++)
        {
            randSpawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPosition, Quaternion.identity);
        }
    }

    void Start()
    {
        SpawnMeteor();
    }

    void Update()
    {
        if (interval <= Time.time)
        {
            MeteorSpawnerWithAnInterval();
        }
    }

    private void MeteorSpawnerWithAnInterval()
    {
        randSpawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
        Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPosition, Quaternion.identity);
        TimerReset();
    }

    void TimerReset()
    {
        interval = Random.Range(minSpawnInterval, maxSpawnInterval) + Time.time;
    }
}
