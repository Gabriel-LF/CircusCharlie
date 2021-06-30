using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyStage : MonoBehaviour
{
    public int rng;
    public string randomTag;
    public int monkeysToSpawn;
    public int bluesToSpawn;

    public float spawnDistance;
    public float spawnDistance2;

    public void StartLevel()
    {
        spawnDistance = LevelManager.Instance.playerPosition + 30;
        spawnDistance2 = LevelManager.Instance.playerPosition + 40;
        int i = 0;
        do
        {
            SpawnObstacle();
            spawnDistance += 10;
            i++;
        } while (i < monkeysToSpawn);
        if (i >= monkeysToSpawn)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
        int a = 0;
        do
        {
            SpawnObstacle2();
            spawnDistance2 += 40;
            a++;
        } while (a < bluesToSpawn);
    }

    public void SpawnObstacle()
    {
        ObjectPooler.Instance.SpawnFromPool("Monkey", new Vector3(spawnDistance, 4, 0), Quaternion.Euler(0, 0, 0));
    }
    public void SpawnObstacle2()
    {
        ObjectPooler.Instance.SpawnFromPool("BlueMonkey", new Vector3(spawnDistance2, 4, 0), Quaternion.Euler(0, 0, 0));
    }
}
