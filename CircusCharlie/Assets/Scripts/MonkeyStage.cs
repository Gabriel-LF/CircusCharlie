using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyStage : MonoBehaviour
{
    public int rng;
    public string randomTag;
    public int monkeysToSpawn;
    public int bluesToSpawn;
    public float begin1, begin2;

    public float spawnDistance;
    public float spawnDistance2;

    public Transform player;
    public Transform rope;

    public int obstacle1, obstacle2;
    public float distance1min, distance1max, distance2min, distance2max;

    public void StartLevel()
    {
        StartCoroutine(RopeAnim());
        
        spawnDistance = LevelManager.Instance.playerPosition + 10;
        spawnDistance2 = LevelManager.Instance.playerPosition + 30;
        int i = 0;
        do
        {
            spawnDistance += Random.Range(distance1min, distance1max);
            //Debug.Log(spawnDistance + " spawned " + i);
            SpawnObstacle();
            i++;
        } while (i < obstacle1);
        if (i >= obstacle1)
            ObjectPooler.Instance.SpawnFromPool("StageChanger", new Vector3(spawnDistance - 15, 0, 0), Quaternion.Euler(0, 0, 0));
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
        ObjectPooler.Instance.SpawnFromPool("Monkey", new Vector3(spawnDistance, 4, 0), Quaternion.Euler(0, 0, 0));
    }
    public void SpawnObstacle2()
    {
        ObjectPooler.Instance.SpawnFromPool("BlueMonkey", new Vector3(spawnDistance2, 4, 0), Quaternion.Euler(0, 0, 0));
    }

    IEnumerator RopeAnim()
    {
        rope.position = new Vector2(player.position.x + 90, 3.5f);
        yield return new WaitForSeconds(0.5f);
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
        player.position = new Vector2(player.position.x, 4.13f);
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
    }
}
