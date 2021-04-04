using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isStatic;
    public bool isRun;
    public bool isRunRight;
    public bool isPatrol;
    public bool shouldWait;
    public bool isWaiting;
    bool goToA, goToB;


    bool wallDetected, pitDetected, isGrounded;

    public float timeToWait;
    public float detectionRadius;
    float speed;

    Rigidbody2D rb2;
    Animator anim;
    public SpriteRenderer sprite;

    public LayerMask whatIsGround;
    public Transform wallCheck, pitCheck, groundCheck;
    public Transform pointA, pointB;

    void Start()
    {
        goToA = true;
        speed = GetComponent<EnemyController>().speed;
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,detectionRadius, whatIsGround);

        if ((pitDetected || wallDetected) && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(isStatic) {
            anim.SetBool("Idle", true);
            rb2.constraints = RigidbodyConstraints2D.FreezeAll;

        } 

        if (isRun) {
            rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);

            if (!isRunRight) {
                rb2.velocity = new Vector2(-speed * Time.deltaTime, rb2.velocity.y);


            } else if(isRunRight) {
                rb2.velocity = new Vector2(speed * Time.deltaTime, rb2.velocity.y);

            }
        }

        if (isPatrol)
        {
            if (goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb2.velocity = new Vector2(-speed * Time.deltaTime, rb2.velocity.y);

                }
                else if (isWaiting)
                {
                    rb2.velocity = new Vector2(0, rb2.velocity.y);

                }

                if (Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {
                    if(shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
               
                    goToA = false;
                    goToB = true;
                    Flip();
                }
            } 
            
            if(goToB)
            {

                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb2.velocity = new Vector2(speed * Time.deltaTime, rb2.velocity.y);

                }
                else if(isWaiting)
                {
                    rb2.velocity = new Vector2(0, rb2.velocity.y);

                }


                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    goToA = true;
                    goToB = false;
                    Flip();
                }
            }
        }
    }

    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();

        yield return new WaitForSeconds(timeToWait);

        isWaiting = false;
        anim.SetBool("Idle", false);
        Flip();
    }

    public void Flip()
    {
        isRunRight = !isRunRight;

        // change checks position
        if(isRunRight)
        {
            pitCheck.transform.localPosition = new Vector2(3, -3);
            wallCheck.transform.localPosition = new Vector2(3, 1);
            sprite.flipX = false;


        } else if(!isRunRight)
        {
            sprite.flipX = true;
            pitCheck.transform.localPosition = new Vector2(-3, -3);
            wallCheck.transform.localPosition = new Vector2(-3, 1);
        }
    }
}
