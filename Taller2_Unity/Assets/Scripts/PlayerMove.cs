using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    public float speed;
    public float jumpForce;
    private bool Grounded;
    private Vector3 initialScale;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
