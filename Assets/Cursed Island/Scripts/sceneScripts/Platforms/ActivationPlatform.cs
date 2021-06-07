using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlatform : MonoBehaviour
{
    public GameObject objectToActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            objectToActive.GetComponent<PlatformMovement>().shouldMove = true;
        }
    }
}
