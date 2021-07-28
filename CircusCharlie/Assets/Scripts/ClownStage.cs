using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ClownStage : MonoBehaviour
{
    public int platformsToSpawn;
    public float begin;

    public float spawnDistance;

    public Transform player;

    public int obstacle;
    public float distancemin, distancemax;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 5;
        int i = 0;
        do
        {
            SpawnObstacle(i);
            spawnDistance += Random.Range(distancemin, distancemax);
            i++;
        } while (i < obstacle);
        if (i >= obstacle)
            ObjectPooler.Instance.SpawnFromPool("ObstacleChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle(int i)
    {
        GameObject platform = ObjectPooler.Instance.SpawnFromPool("Platoform", new Vector3(spawnDistance, 7.8f, 0), Quaternion.Euler(0, 0, 0));
        if (i == 0)
            player.position = platform.transform.position;
    }
}