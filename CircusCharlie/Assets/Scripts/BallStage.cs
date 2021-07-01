using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallStage : MonoBehaviour
{
    public int ballsToSpawn;
    public float begin;

    public float spawnDistance;

    public Transform player;

    public int obstacle;
    public float distancemin, distancemax;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 15;
        int i = 0;
        do
        {
            SpawnObstacle();
            spawnDistance += Random.Range(distancemin, distancemax);
            i++;
        } while (i < obstacle);
        if (i >= obstacle)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool("Ball", new Vector3(spawnDistance, 0.15f, 0), Quaternion.Euler(0, 0, 0));
    }
}
