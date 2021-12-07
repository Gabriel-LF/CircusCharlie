using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BonusStage : MonoBehaviour
{
    public int rng;
    public string randomTag;
    public int moneyToSpawn;
    public float begin1;

    public float spawnDistance;

    public int obstacle1;
    public float distance1min, distance1max;

    public Transform player;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 10;
        int i = 0;
        do
        {
            spawnDistance += Random.Range(distance1min, distance1max);
            SpawnObstacle();
            i++;
        } while (i < obstacle1);
        if (i >= obstacle1)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance - 10, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool(randomTag, new Vector3(spawnDistance, 3, 0), Quaternion.Euler(0, 0, 0));
    }
}
