using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyController enemy;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    bool isDamaged;
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
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);
            enemy.healthPoints -= 1f;

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            } 
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }

            StartCoroutine(Damage());

            if(enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                AudioManager.instance.PlayAudio(AudioManager.instance.deathEnemy);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damage()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(1.0f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
