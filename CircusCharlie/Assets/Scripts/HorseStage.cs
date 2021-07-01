using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HorseStage : MonoBehaviour
{
    public int rng;
    public int jumpsToSpawn;
    public float begin;

    public float spawnDistance;

    public Transform player;

    public float h1, h2;

    public int obstacle;
    public float distancemin, distancemax;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 10;
        int i = 0;
        int a = 0;
        do
        {
            if (a == 0)
            {
                a = 1;
                h1 = Random.Range(0.05f, 5);
                SpawnObstacle();
                spawnDistance += 2.5f;
            } else {
                a = 0;
                if (h1 <= 1.5f)
                { h2 = Random.Range(0.6f, 6f); }
                else { h2 = Random.Range(0.01f, 0.4f); }
                SpawnObstacle2();
                spawnDistance += Random.Range(distancemin, distancemax);
            }
            i++;
        } while (i < obstacle);
        if (i >= obstacle)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool("Jump", new Vector3(spawnDistance, h1, 0), Quaternion.Euler(0, 0, 0));
    }
    public void SpawnObstacle2()
    {
        ObjectPooler.Instance.SpawnFromPool("Jump", new Vector3(spawnDistance, h2, 0), Quaternion.Euler(0, 0, 0));
    }
}