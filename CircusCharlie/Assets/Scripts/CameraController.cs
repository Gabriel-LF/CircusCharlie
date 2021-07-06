using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float x, y, z;
    public bool horse;

    // Update is called once per frame
    void Update()
    {
        if (!horse)
            transform.position = new Vector3(player.transform.position.x + x, y, z);
        if (horse && !player.gameObject.GetComponent<PlayerProgress>().freeHorse)
            transform.position = new Vector3(player.transform.position.x + x, y, z);
    }
}
