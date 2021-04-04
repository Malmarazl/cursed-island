using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float knockbackForce;

    public float inmunityTime;
    bool isInmune;

    public GameObject gameOver;
    Rigidbody2D rb2;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver.SetActive(false);

        // If player cure
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        PlayerDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<EnemyController>().damage;
            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rb2.AddForce(new Vector2 (-knockbackForce, 0), ForceMode2D.Force);

            } else {

                rb2.AddForce(new Vector2(knockbackForce, 0), ForceMode2D.Force);
            }

        }
    }

    private void PlayerDeath()
    {
        if (health <= 0)
        {
            Debug.Log("Player dead");
            PlayerPrefs.DeleteAll(); // Remove checkpoints
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        anim.SetBool("Hurt", true);

        yield return new WaitForSeconds(inmunityTime);


        anim.SetBool("Hurt", false);
        isInmune = false;
    }
}
