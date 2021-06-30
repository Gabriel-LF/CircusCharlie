using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float x, y, z;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + x, y, z);
    }
}
