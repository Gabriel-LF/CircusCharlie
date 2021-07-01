using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

    public bool hasBall;
    public Transform ballPosition;
    public float ballTimer;

    public bool hasStarted = false;
    public float beginTimer;
    public Animator anim;

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
            if(beginTimer > 1)
            jumpTimer = Time.time + jumpDelay;
        }
        gameObject.GetComponent<PlayerAnimation>().anim.SetBool("isMountJumping", onGround);
        anim.SetBool("isGrounded", onGround);

        if (onGround && gameObject.GetComponent<PlayerAnimation>().ballStage == true && hasBall == false && ballTimer > 1)
            gameObject.GetComponent<PlayerProgress>().Die();

        if (!hasBall && gameObject.GetComponent<PlayerAnimation>().ballStage == true)
            ballTimer += Time.deltaTime;

        if (hasStarted)
            beginTimer += Time.deltaTime;
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

        if (hasBall && gameObject.GetComponent<PlayerAnimation>().ballStage == true)
        {
            GameObject ball = ObjectPooler.Instance.SpawnFromPool("Ball", new Vector3(ballPosition.position.x - 1, ballPosition.position.y, 0), Quaternion.Euler(0, 0, 0));
            ball.layer = 2;
            ball.GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpSpeed, ForceMode2D.Impulse);
            hasBall = false;
            ballPosition.gameObject.SetActive(false);
            ballTimer = 0;
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
            } else if (rb.velocity.y > 0)
            {
                if(!Input.GetButton("Jump"))
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

    public void Unstart()
    {
        hasStarted = true;
        beginTimer = 0;
    }
}
