using UnityEngine;

public class HeroControl : MonoBehaviour
{
    [Header("Hero Settings")]                                                        // Hero settings variable ( speed moving + jump)
    [SerializeField] private float moveSpeed = 2.1f;
    [SerializeField] private float jumpForse = 3.0f;
    [SerializeField] private float jumpThreshold = 0.5f;

    [Header("Ground Check Settings")]                                               // Ground Chek 
    public Transform groundCheck;
    private float GroundRadius = 0.3f;
    public LayerMask groundMask;

    private Rigidbody2D rb;                                                         // Inspektor Settings
    private SpriteRenderer spriteRender;
    private Animator animator;
    private bool isGroundet;
    private bool doubleJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        HeroMovent();
        JumpHeroMovent();
        HeroFlip();
    }

    private void HeroMovent()                                                     // Movings 
    {
        float moveInput = Input.GetAxis("Horizontal");
        float SprintSpeed = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1.0f;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed * SprintSpeed, rb.linearVelocity.y);

        //  ������������ ��������
        bool isWalking = Mathf.Abs(moveInput) > 0.01f;                            // Animators
        animator.SetBool("WalkBool", isWalking);

        Debug.Log($"�������� = {moveSpeed * SprintSpeed}");
    }

    private void JumpHeroMovent()                                                 // Jump
    {
        isGroundet = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, groundMask);

        if (isGroundet)
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))                                      //checking the keystroke
        {                  

            if (isGroundet)
            {
                rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
            }
            else if (!doubleJump && rb.linearVelocityY <= jumpThreshold)         //if the vertical speed is lower
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);         //reset the vertical speed
                rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
                doubleJump = true;
            }
        }
    }

    private void HeroFlip()                                                       // flip
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0)
        {
            spriteRender.flipX = moveInput < 0;
        }
    }
}





    //transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal");      // �������� �� ��� �

    //isGroundet = Physics2D.OverlapCircle(groundCheck.position,GroundRadius, groundMask);

    //if (Input.GetAxis("Horizontal") < 0)                                               // ������� ���������
    //{
    //    GetComponent<SpriteRenderer>().flipX = true;  // �����
    //}
    //else if (Input.GetAxis("Horizontal") >0)
    //{
    //    GetComponent<SpriteRenderer>().flipX = false; // �����
    //}

    //if (Input.GetKeyDown(KeyCode.Space) && isGroundet)
    //{
    //    bodyPhysic.AddForce(new Vector2(0, 200));
    //}

