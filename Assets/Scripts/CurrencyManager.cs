using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
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

    [SerializeField]
    private int currencyCount = 500;

    public TextMeshProUGUI currencyCountText;

    public int CurrencyCount { get { return currencyCount; } set { currencyCount = value; currencyCountText.text = value.ToString(); } }

    public bool UpgradeCurrencyCount(int amount)
    {
        int initialCount = CurrencyCount;
        CurrencyCount += amount;

        return CurrencyCount != initialCount;
    }
}
