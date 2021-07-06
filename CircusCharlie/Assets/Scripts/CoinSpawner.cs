using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int chanceToSpawn;
    public GameObject coinObject;

    private int rng;

    // Start is called before the first frame update
    void OnEnable()
    {
        rng = Random.Range(1, 101);
        if (rng <= chanceToSpawn)
            coinObject.SetActive(true);
    }

    // Update is called once per frame
    void OnDisable()
    {
        coinObject.SetActive(false);
    }
}
