using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public bool dontMove;
    private float currentSpeed;

    void Start()
    {
        dontMove = true;
    }

    void Update()
    {
        if(!dontMove)
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    public void Halt()
    {

    }
}
