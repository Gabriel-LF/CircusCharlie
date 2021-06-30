using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public bool dontMove;

    void Start()
    {
        dontMove = true;
    }

    void Update()
    {
        if(!dontMove)
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
