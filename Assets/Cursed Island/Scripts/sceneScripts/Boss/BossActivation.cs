using System.Collections;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGo;

    private void Start()
    {
        bossGo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivate();
            StartCoroutine(WaitForBoss());
        }
    }

    IEnumerator WaitForBoss()
    {
        PlayerController.instance.runSpeed = 0;
        bossGo.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerController.instance.runSpeed = 300;
        Destroy(gameObject);
    }
}
