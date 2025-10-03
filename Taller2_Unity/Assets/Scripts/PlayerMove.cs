using System;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    public float speed;
    public float jumpForce;
    private Vector3 initialScale;

    private bool isGrounded;
    private int jumpCount;
    public int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialScale = transform.localScale;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f)
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        else if (horizontal > 0.0f)
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);

        animator.SetBool("running", horizontal != 0.0f);

        if (isGrounded) jumpCount = 0;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
            jumpCount++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }

        if (!isGrounded)
        {
            if (rb.linearVelocity.y > 1f)
            {
                animator.SetBool("jumping", true);
                animator.SetBool("falling", false);
            }
            else if (rb.linearVelocity.y < -1f)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
            }
        }
        else
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    internal void RecibeDanio(Vector2 direcciondanio, int v)
    {
        throw new NotImplementedException();
    }
}
