using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDay : MonoBehaviour
{
    public SpriteRenderer sprite;
    public static ChangeDay instance;

    public bool day;
    public string currentDay;
    bool hasEntered = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentDay = PlayerPrefs.GetString("currentDay", currentDay);

        if(currentDay == "nigth")
        {
            day = false;
        } else
        {
            day = true;
        }

    }

    private void Update()
    {
        updateDay();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            day = !day;
        } else
        {
            hasEntered = false;
        }
    }

    void updateDay()
    {
        if(day)
        {
            currentDay = "day";
            //day D4C873 
            sprite.color = new Color32(212, 200, 115, 255);
        }
        else if (!day)
        {
            currentDay = "nigth";
            //night 8173D4 
            sprite.color = new Color32(129, 115, 212, 255);
        }
    }
}
