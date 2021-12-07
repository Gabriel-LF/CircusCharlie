using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ClownStage : MonoBehaviour
{
    // MIN HEIGHT IS 0, MAX HEIGHT IS 6

    public int platformsToSpawn;
    public float begin;

    public float spawnDistance;

    public Transform player;

    public int obstacle;
    public float distancemin, distancemax;

    public Transform startingPlatform;
    public float currentHeight;

    public void StartLevel()
    {
        StartCoroutine(PlatformAnim());
        currentHeight = 2.5f;

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
        currentHeight += Random.Range(-3f,3f);
        if (currentHeight > 6) currentHeight = 6;
        if (currentHeight < 0.5f) currentHeight = 0.5f;

        GameObject platform = ObjectPooler.Instance.SpawnFromPool("Platform", new Vector3(spawnDistance, currentHeight, 0), Quaternion.Euler(0, 0, 0));
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