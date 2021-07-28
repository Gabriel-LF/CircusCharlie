using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SwingStage : MonoBehaviour
{
    public int swingsToSpawn;
    public float begin;

    public float spawnDistance;

    public Transform player;

    public int obstacle;
    public float distancemin, distancemax;

    public bool lastWasLeft = false;

    public void StartLevel()
    {
        player.position = new Vector2(player.position.x, 0);

        spawnDistance = LevelManager.Instance.playerPosition + 10;
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
        int rng = Random.Range(0, 3);
        if (rng == 0) { spawnDistance -= 1.25f; lastWasLeft = true; }
        if (rng == 2) { spawnDistance += 0.3f; if (!lastWasLeft) { spawnDistance -= 1.25f; } lastWasLeft = true; }
        if (rng == 1 && lastWasLeft) { spawnDistance -= 0.25f; lastWasLeft = false; }
        GameObject swing = ObjectPooler.Instance.SpawnFromPool("Swing", new Vector3(spawnDistance, 7.8f, 0), Quaternion.Euler(0, 0, 0));
        swing.layer = 0;
        swing.GetComponent<SwingType>().SetType(rng);
        if (i == 0)
            player.position = swing.transform.GetChild(0).transform.GetChild(1).transform.position;
    }
}