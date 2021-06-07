using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTower : MonoBehaviour
{
    public GameObject brokenEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Instantiate(brokenEffect, new Vector3(171.6f, -70f, 0.0f), Quaternion.identity);
            AudioManager.instance.PlayAudio(AudioManager.instance.deathEnemy);
            Destroy(gameObject);
        }
    }
}
