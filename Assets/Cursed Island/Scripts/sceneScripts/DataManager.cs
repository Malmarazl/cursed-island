using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

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
        DontDestroyOnLoad(gameObject);
    }

    public void CurrentHearts(float value)
    {
        PlayerPrefs.SetFloat("currentHearts", value);
    }

    public void CurrentCoins(int value)
    {
        PlayerPrefs.SetInt("currentCoins", value);
    }

    public void CurrentDay(string value)
    {
        PlayerPrefs.SetString("currentDay", value);
    }
    public void CurrentBridge(string value)
    {
        PlayerPrefs.SetString("currentBridge", value);
    }

}
