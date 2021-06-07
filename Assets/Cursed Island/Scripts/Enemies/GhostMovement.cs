using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject target;

    public float ratio = 50;
    bool gotIt;
    public float range;

    public bool isEater;

    public Transform pointA, pointB;
    public SpriteRenderer spriteNormalGhost;

    public float speed;
    public bool shouldWait;
    public float timeToWait;

    public bool moveToA, moveToB;
    bool canContinue;

    private void Start()
    {
        canContinue = true;
    }

    void Update()
    {
        if(isEater)
        {
            EaterMovement();
        } else
        {
            NormalMovement();
        }
    }

    private void EaterMovement()
    {
        if (!gotIt)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

            foreach (Collider2D h in hits)
            {
                if (h.gameObject == target)
                {
                    gotIt = true;
                    break;
                }
            }
        }

        if (gotIt)
        {

            float step;

            if (Vector3.Dot(target.transform.position - transform.position, target.transform.localScale.x * Vector3.right) > 0)
            {
                step = ratio * 5f;
                GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
            else
            {
                AudioManager.instance.PlayAudio(AudioManager.instance.ghost);
                step = ratio;
                GetComponent<SpriteRenderer>().sprite = sprites[0];
            }

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * Time.deltaTime * 10);
        }
    }

    private void NormalMovement()
    {

        float distanceToA = Vector2.Distance(transform.position, pointA.position);
        float distanceToB = Vector2.Distance(transform.position, pointB.position);

        if (distanceToA > 0.1f && moveToA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (distanceToA < 0.3f && canContinue)
            {
                if (shouldWait)
                {
                    StartCoroutine(Wait());
                    moveToA = false;
                    moveToB = true;
                    spriteNormalGhost.flipX = false;
                }
                else
                {
                    moveToA = false;
                    moveToB = true;
                    spriteNormalGhost.flipX = false;
                }
            }
        }

            if (distanceToB > 0.1f && moveToB)
            {
                transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
                if (distanceToB < 0.3f && canContinue)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Wait());
                        moveToA = true;
                        moveToB = false;
                        spriteNormalGhost.flipX = true;
                    }
                    else
                    {
                        moveToA = true;
                        moveToB = false;
                        spriteNormalGhost.flipX = true;
                }

                }
            }
    }

    IEnumerator Wait()
    {
        canContinue = false;
        yield return new WaitForSeconds(timeToWait);
        canContinue = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
