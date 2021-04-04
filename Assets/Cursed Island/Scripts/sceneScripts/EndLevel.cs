using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    public GameObject endLevel;

    void Start()
    {
        endLevel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.DeleteAll();
            Time.timeScale = 0;
            endLevel.SetActive(true);
            Debug.Log("Fin de nivel");
        }
    }
}
