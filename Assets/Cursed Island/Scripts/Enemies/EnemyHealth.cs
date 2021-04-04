using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyController enemy;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    public bool isDamaged;
    public GameObject deathEffect;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<EnemyController>();
        material = GetComponent<Blink>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon") && !isDamaged)
        {
            enemy.healthPoints -= 1f;

            if(collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            } 
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }

            StartCoroutine(Damager());

            if(enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
