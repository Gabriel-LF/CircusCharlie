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

    public Transform startingPlatform;

    public void StartLevel()
    {
        StartCoroutine(PlatformAnim());

        spawnDistance = LevelManager.Instance.playerPosition + 15;
        int i = 0;
        do
        {
            SpawnObstacle(i);
            SpawnClown(Random.Range(1,4));
            spawnDistance += Random.Range(distancemin, distancemax);
            i++;
        } while (i < obstacle);
        if (i >= obstacle)
            ObjectPooler.Instance.SpawnFromPool("ObstacleChanger", new Vector3(spawnDistance, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SpawnObstacle(int i)
    {
        GameObject platform = ObjectPooler.Instance.SpawnFromPool("Platform", new Vector3(spawnDistance, 2.5f, 0), Quaternion.Euler(0, 0, 0));
        //if (i == 0)
        //    player.position = platform.transform.position;
    }
    public void SpawnClown(int rng)
    {
        if(rng < 3)
            ObjectPooler.Instance.SpawnFromPool("FireClown", new Vector3(spawnDistance + 2.65f, 0, 0), Quaternion.Euler(0, 0, 0));
        else ObjectPooler.Instance.SpawnFromPool("KnifeClown", new Vector3(spawnDistance + 2.65f, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    IEnumerator PlatformAnim()
    {
        startingPlatform.gameObject.SetActive(false);
        startingPlatform.gameObject.SetActive(true);
        startingPlatform.position = new Vector2(player.position.x, startingPlatform.position.y);
        yield return new WaitForSeconds(0.5f);
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
        player.position = new Vector2(player.position.x, 4.13f);
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
    }
}