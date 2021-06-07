using UnityEngine;

public class BananasController : MonoBehaviour
{

    public float healthToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health += healthToGive;
            AudioManager.instance.PlayAudio(AudioManager.instance.banana);
            Destroy(gameObject);
        }
    }
}
