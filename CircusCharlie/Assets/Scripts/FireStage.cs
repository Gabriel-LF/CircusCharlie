using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FireStage : MonoBehaviour
{
    public int rng;
    public string randomTag;
    public int circlesToSpawn;
    public int jarsToSpawn;
    public float begin1, begin2;

    public float spawnDistance;
    public float spawnDistance2;

    public int obstacle1, obstacle2;
    public float distance1min, distance1max, distance2min, distance2max;

    public Transform player;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 30;
        spawnDistance2 = LevelManager.Instance.playerPosition + 40;
        int i = 0;
        do {
            spawnDistance += Random.Range(distance1min, distance1max);
            SpawnObstacle();
            i++;
        } while (i < obstacle1);
        if(i >= obstacle1)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance-10, 0, 0), Quaternion.Euler(0, 0, 0));
        int a = 0;
        do
        {
            spawnDistance2 += Random.Range(distance2min, distance2max);
            SpawnObstacle2();
            a++;
        } while (a < obstacle2);
    }

    public void SpawnObstacle()
    {
        RandomizeObstacle();
        ObjectPooler.Instance.SpawnFromPool(randomTag, new Vector3(spawnDistance, 3, 0), Quaternion.Euler(0, 0, 0));
    }
    public void SpawnObstacle2()
    {
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
