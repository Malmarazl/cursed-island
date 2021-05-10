using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{

    public GameObject bossPanel;
    public GameObject walls;
    public static BossUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);
    }

    public void BossActivate()
    {
        bossPanel.SetActive(true);
        walls.SetActive(true);
    }

    public void BossDesactivate()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);
        BossDefeated();
    }

    IEnumerator BossDefeated()
    {
        PlayerController.instance.enabled = false;
        PlayerController.instance.runSpeed = 0;
        yield return new WaitForSeconds(3);
        PlayerController.instance.enabled = true;
        PlayerController.instance.runSpeed = 300;
    }
}
