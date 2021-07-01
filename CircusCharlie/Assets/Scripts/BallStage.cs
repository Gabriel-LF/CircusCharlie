using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallStage : MonoBehaviour
{
    public int ballsToSpawn;

    public float spawnDistance;

    public Transform player;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 30;
        int i = 0;
        do
        {
            SpawnObstacle();
            spawnDistance += 30;
            i++;
        } while (i < ballsToSpawn);
        if (i >= ballsToSpawn)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool("Ball", new Vector3(spawnDistance, 0.15f, 0), Quaternion.Euler(0, 0, 0));
    }
}
