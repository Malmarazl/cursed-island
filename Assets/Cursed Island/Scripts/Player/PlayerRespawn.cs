using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    int firstCollision = 0;

    PlayerHealth playerHealth;
    Blink material;
    SpriteRenderer sprite;

    void Start()
    { 
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();

        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
    }


    public void ReachedCheckpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OutLevel") && firstCollision == 0 && playerHealth.health > 0)
        {
            firstCollision++;
            playerHealth.health -= 1f;
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        if (playerHealth.health > 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
            sprite.material = material.blink;
            yield return new WaitForSeconds(0.3f);
            sprite.material = material.original;
            firstCollision = 0;
        }
    }

}
