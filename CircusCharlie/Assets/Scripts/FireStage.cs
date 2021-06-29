using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStage : MonoBehaviour
{
    public int rng;
    public string randomTag;
    public int circlesToSpawn;
    public int jarsToSpawn;

    public float spawnDistance;
    public float spawnDistance2;

    public void StartLevel()
    {
        spawnDistance = LevelManager.Instance.playerPosition + 30;
        spawnDistance2 = LevelManager.Instance.playerPosition + 40;
        int i = 0;
        do {
            SpawnObstacle();
            spawnDistance += 10;
            i++;
        } while (i < circlesToSpawn);
        int a = 0;
        do
        {
            SpawnObstacle2();
            spawnDistance2 += 20;
            a++;
        } while (a < jarsToSpawn);
    }

    public void SpawnObstacle()
    {
        RandomizeObstacle();
        ObjectPooler.Instance.SpawnFromPool(randomTag, new Vector3(spawnDistance, 5, 0), Quaternion.Euler(0, 0, 0));
    }
    public void SpawnObstacle2()
    {
        RandomizeObstacle();
        ObjectPooler.Instance.SpawnFromPool("FireJar", new Vector3(spawnDistance2, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void RandomizeObstacle()
    {
        rng = Random.Range(0, 3);
        if (rng < 2)
            randomTag = "BigCircle";
        if (rng == 2)
            randomTag = "SmallCircle";
    }
}
