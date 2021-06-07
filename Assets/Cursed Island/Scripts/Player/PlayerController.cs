using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatsIsGround;

    public float runSpeed;

    private bool moveLeft;
    private bool moveRight;

    Rigidbody2D rb2;
    Animator anim;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatsIsGround);
        Movement();
        FlipCharacter();

        // Animation Jump
        if (isGrounded && rb2.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void Movement()
    {
        if (moveLeft) {
            rb2.velocity = new Vector2(-runSpeed * Time.fixedDeltaTime, rb2.velocity.y);

        } else if (moveRight) {
            rb2.velocity = new Vector2(runSpeed * Time.fixedDeltaTime, rb2.velocity.y);

        } else {
            rb2.velocity = new Vector2(0, rb2.velocity.y);
        }

        // Animation for move
        if (rb2.velocity.x != 0) {
            anim.SetBool("Run", true);
        } 
        else {
            anim.SetBool("Run", false);
        }
    }

    public void FlipCharacter()
    {
        if (rb2.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (rb2.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            AudioManager.instance.RandomJump();
            rb2.velocity = new Vector2(rb2.velocity.x, jumpHeight);
        }
    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
        AudioManager.instance.PlayAudio(AudioManager.instance.sword);
    }
    public void NoAttack()
    {
        anim.SetBool("Attack", false);
    }
}
