using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BonusStage : MonoBehaviour
{
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
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance + distance1min, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool("Money", new Vector3(spawnDistance, Random.Range(0.5f,6f), 0), Quaternion.Euler(0, 0, 0));
    }
}
