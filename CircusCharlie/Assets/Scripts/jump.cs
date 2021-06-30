using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool onGround;
    private float jumpTimer;
    private Rigidbody2D rb;
    public float groundLenght;
    public Vector3 colliderOffset;
    [Header("fisica do pulo")]
    public float jumpSpeed;
    public float jumpDelay = 0.25f;
    public float gravity = 1;
    public float fallMultiplier = 5;
    public float linearDrag = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ModifyPhysics();
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLenght, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLenght, groundLayer);

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        gameObject.GetComponent<PlayerAnimation>().anim.SetBool("isMountJumping", onGround);
    }

    private void FixedUpdate()
    {
        if(jumpTimer > Time.time && onGround)
        {
            Jump();
        }
    }

    void Jump()
    {
        if(gameObject.GetComponent<PlayerMove>().dontMove == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTimer = 0;
        }
    }

    void ModifyPhysics()
    {
        if (onGround)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLenght);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLenght);
    }
}
