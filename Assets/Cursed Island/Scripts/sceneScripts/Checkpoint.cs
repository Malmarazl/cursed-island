using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Guardado!");
            AudioManager.instance.PlayAudio(AudioManager.instance.saveGame);
            DataManager.instance.CurrentHearts(PlayerHealth.instance.health);
            DataManager.instance.CurrentCoins(CoinCount.instance.coinsCount);
            DataManager.instance.CurrentDay(ChangeDay.instance.currentDay);
            DataManager.instance.CurrentBridge(ActivationBridge.instance.currentBridge);
            collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(transform.position.x, transform.position.y);
            collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(transform.position.x, transform.position.y);
        }
    }
}

