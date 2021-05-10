using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    PlayerController target;
    public SpriteRenderer spriteFlama;

    void Start()
    {
        moveSpeed = GetComponent<EnemyController>().speed;
        spriteFlama = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        target = PlayerController.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);

        if (transform.position.x > PlayerController.instance.transform.position.x)
        {
            spriteFlama.flipX = true;
        }
        else
        {
            spriteFlama.flipX = false;
        }
    }
}
