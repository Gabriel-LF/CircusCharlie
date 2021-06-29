using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
