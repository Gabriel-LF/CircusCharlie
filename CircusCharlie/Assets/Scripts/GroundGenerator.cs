using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public float distanceToSpawn = 100;
    public float distanceWalked;
    public Transform player;
    public GameObject ground;
    public float dif;

    public bool cooldown;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > distanceWalked)
            distanceWalked = player.position.x;

        dif = distanceWalked % 25;
        if (dif <= 1 && distanceWalked > 1 && !cooldown)
        {
            Instantiate(ground, new Vector3(distanceToSpawn, -1.1f, 0), Quaternion.identity);
            distanceToSpawn += 100;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        cooldown = true;
        yield return new WaitForSeconds(5f);
        cooldown = false;
    }
}
