using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{

    public int coinsCount, currentCoins;
    public Text coinText;

    public static CoinCount instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins", coinsCount);
        coinsCount = currentCoins;
        coinText.text = "x " + coinsCount.ToString();
    }

    public void Money(int coinCollected)
    {
        coinsCount += coinCollected;
        coinText.text = "x " + coinsCount.ToString();
    }
}
