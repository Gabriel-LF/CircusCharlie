using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonkey : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpSpeed;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void OnEnable()
    //{
    //    gameObject.layer = 0;
    //}

    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Hazard"))
        {
            Jump();
        }
    }
    //void OnCollisionEnter2D(Collision2D hit)
    //{
    //    if (hit.gameObject.CompareTag("Player"))
    //    {
    //        gameObject.layer = 2;
    //    }
    //}

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        anim.SetTrigger("Jump");
    }
}
