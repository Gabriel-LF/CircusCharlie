using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFreeMove : MonoBehaviour
{
    public float speed;
    public bool up, left, right, down;

    void Update()
    {
        if (up) transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (left) transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (right) transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (down) transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
