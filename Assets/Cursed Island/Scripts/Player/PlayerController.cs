using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float jump;

    public bool betterJump = false;
    public float fallMultipler = 0.5f;
    public float lowJumpMultipler = 1f;

    public float runSpeed = 4;
    private bool moveLeft;
    private bool moveRight;

    public SpriteRenderer sprite;

    Rigidbody2D rigidbody2D;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FlipCharacter();
    }

    void FixedUpdate()
    {

        if (CheckGround.isGrounded)
        {
            anim.SetBool("Jump", false);
        } else
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
            rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);

        } else if (moveRight) {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);

        } else {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }

        // Animation for move
        if (rigidbody2D.velocity.x != 0) {
            anim.SetBool("Run", true);
        } 
        
        else {
            anim.SetBool("Run", false);
        }
    }

    public void FlipCharacter()
    {
        if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector2(0.5f, transform.localScale.y);
        }
        else if (rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector2(-0.5f, transform.localScale.y);
        }
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump);
        }

        if (betterJump && CheckGround.isGrounded)
        {
            if (rigidbody2D.velocity.y < 0)
            {
                rigidbody2D.velocity += Vector2.up * Physics.gravity.y * (fallMultipler) * Time.deltaTime;
            }

            if (rigidbody2D.velocity.y > 0)
            {
                rigidbody2D.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultipler) * Time.deltaTime;
            }
        }
    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
    }

    // When attack animation finish
    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            anim.SetBool("Attack", false);
        }
    }



}
