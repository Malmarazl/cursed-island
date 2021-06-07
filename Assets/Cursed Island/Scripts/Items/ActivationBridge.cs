using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBridge : MonoBehaviour
{
    public GameObject [] bridges;
    bool toggle = false;
    public string currentBridge;

    public static ActivationBridge instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

        currentBridge = PlayerPrefs.GetString("currentBridge", currentBridge);

        if(currentBridge == "true" )
        {
            toggle = true;
        } else
        {
            toggle = false;
        }

        if(!toggle)
        {
            bridges[0].SetActive(true);
            bridges[1].SetActive(true);
            bridges[2].SetActive(false);
        } else
        {
            bridges[0].SetActive(false);
            bridges[1].SetActive(false);
            bridges[2].SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon") && !toggle)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.switcher);
            toggle = true;
            currentBridge = "true";
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            bridges[0].SetActive(false);
            bridges[1].SetActive(false);
            bridges[2].SetActive(true);
            AudioManager.instance.PlayAudio(AudioManager.instance.fallBridge);
        }
    }
}
