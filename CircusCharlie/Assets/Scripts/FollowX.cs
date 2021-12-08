using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(target.position.x, transform.position.y);
    }
}
