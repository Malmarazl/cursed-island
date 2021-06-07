using UnityEngine;

public class EndLevel : MonoBehaviour
{

    public GameObject endLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            endLevel.SetActive(true);
            AudioManager.instance.StopAudioBackgroundMusic();
            AudioManager.instance.PlayAudio(AudioManager.instance.levelComplete);
            Debug.Log("Fin de nivel");
        }
    }
}
