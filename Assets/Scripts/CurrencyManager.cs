using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    //Singleton of CurrencyManager
    public static CurrencyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Private Variable for setting amount of Player Coins 
    [SerializeField]
    private int currencyCount = 500;

    //Public Variable
    public TextMeshProUGUI currencyCountText;

    //Property
    public int CurrencyCount { get { return currencyCount; } set { currencyCount = value; currencyCountText.text = value.ToString(); } }

    public bool UpdateCurrencyCount(int amount)
    {
        int initialCount = CurrencyCount;
        CurrencyCount += amount;

        return CurrencyCount != initialCount;
    }
}
