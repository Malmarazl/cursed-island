using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float knockbackForce;
    float currentHearts;

    public float inmunityTime;
    bool isInmune;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOver;
    Rigidbody2D rb2;
    Animator anim;
    public static PlayerHealth instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentHearts = PlayerPrefs.GetFloat("currentHearts", health);
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        gameOver.SetActive(false);

        if(currentHearts > 0)
        {
            health = currentHearts;
        } else
        {
            health = maxHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // If player health
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        generateHearts();
    }

    private void generateHearts()
    {
        for(int i=0; i < maxHealth; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;

            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth)
            {
                hearts[i].enabled = true;

            } else {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<EnemyController>().damage;
            AudioManager.instance.PlayAudio(AudioManager.instance.hitplayer);
            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rb2.AddForce(new Vector2 (-knockbackForce, 10), ForceMode2D.Force);

            } else {

                rb2.AddForce(new Vector2(knockbackForce, 10), ForceMode2D.Force);
            }
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        if (health < 1)
        {
            Debug.Log("Player dead");
            Time.timeScale = 0;
            gameOver.SetActive(true);
            AudioManager.instance.StopAudioBackgroundMusic();
            AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);
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
