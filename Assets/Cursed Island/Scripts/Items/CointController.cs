using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointController : MonoBehaviour
{
    public int cashToGive;
    int oneCollission = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && oneCollission == 0)
        {
            oneCollission++;
            CoinCount.instance.Money(cashToGive);
            Destroy(gameObject);
        }
    }
}
