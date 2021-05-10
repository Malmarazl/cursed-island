using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform pointA, pointB;

    public float speed;
    public bool shouldMove;
    public bool shouldWait;
    public float timeToWait;

    public bool moveToA, moveToB;
    bool canContinue;

    private void Start()
    {
        canContinue = true;
    }

    private void Update()
    {
        if(shouldMove)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        float distanceToA = Vector2.Distance(transform.position, pointA.position);
        float distanceToB = Vector2.Distance(transform.position, pointB.position);

        if(distanceToA > 0.1f && moveToA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed*Time.deltaTime);
            if(distanceToA < 0.3f && canContinue)
            {
                if(shouldWait)
                {
                    StartCoroutine(Wait());
                    moveToA = false;
                    moveToB = true;
                }
                else
                {
                    moveToA = false;
                    moveToB = true;
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
                } else
                {
                    moveToA = false;
                    moveToB = true;
                }

            }
        }
    }

    IEnumerator Wait()
    {
        shouldMove = false;
        canContinue = false;
        yield return new WaitForSeconds(timeToWait);
        shouldMove = true;
        canContinue = true;
    }
}
