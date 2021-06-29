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

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        do {
            SpawnObstacle();
            spawnDistance += 10;
        } while (i < circlesToSpawn);
    }

    public void SpawnObstacle()
    {
        RandomizeObstacle();
        ObjectPooler.Instance.SpawnFromPool(randomTag, new Vector3(spawnDistance, 10, 0), Quaternion.Euler(0, 0, 0));
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
