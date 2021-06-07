using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGhost : MonoBehaviour
{
    public GameObject ghostEater;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.deathEnemy);
            Destroy(ghostEater);
        }
    }
}
