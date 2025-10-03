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

    private bool enSuelo;
    private bool recibiendoDanio;


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
        Debug.DrawRay(transform.position, Vector3.down * 2f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 2f))
        {
            Grounded = true;
            animator.SetBool("jumping", false);
        }
        else
        {
            Grounded = false;
            animator.SetBool("jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
            animator.SetBool("recibeDanio", recibiendoDanio);
           
        }

        


    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    //------------Funciòn Recibir Daño----------
    public void RecibeDanio (Vector2 direccion, int cantDanio)
    {
        if(!recibiendoDanio)
        {
            recibiendoDanio = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;
            rb.AddForce(rebote, ForceMode2D.Impulse);
        }
    }

    public void DesactivaDanio() 
    {
        recibiendoDanio = false;
    
 
    }






}


