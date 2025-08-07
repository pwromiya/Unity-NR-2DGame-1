using UnityEngine;

public class HeroControl : MonoBehaviour
{
    [Header("Hero Settings")]
    [SerializeField] private float moveSpeed = 2.1f;
    [SerializeField] private float jumpForse = 3.0f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    private float GroundRadius = 0.3f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Animator animator;
    private bool isGroundet;

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

    private void HeroMovent()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float SprintSpeed = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1.0f;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed * SprintSpeed, rb.linearVelocity.y);

        //  ������������ ��������
        bool isWalking = Mathf.Abs(moveInput) > 0.01f;
        animator.SetBool("WalkBool", isWalking);

        Debug.Log($"�������� = {moveSpeed * SprintSpeed}");
    }

    private void JumpHeroMovent()
    {
        isGroundet = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGroundet)
        {
            rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        }
    }

    private void HeroFlip()
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

