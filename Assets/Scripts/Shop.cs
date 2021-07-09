using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

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

    public HeadClothing[] headClothing;
    public BodyClothing[] bodyClothing;

    public GameObject catalog;
    public GameObject shopKeeperInteraction;

    public void OpenCatalog()
    {
        catalog.SetActive(true);
        HideInteraction();
    }

    public void CloseCatalog()
    {
        catalog.SetActive(false);
    }

    public void ShowInteraction()
    {
        if (!catalog.activeSelf && !CharacterManager.instance.characterInventory.inventoryPanel.activeSelf)
            shopKeeperInteraction.SetActive(true);
    }

    public void HideInteraction()
    {
        shopKeeperInteraction.SetActive(false);
    }

    public void PurchaseHeadClothing(int id)
    {
        if (id < headClothing.Length)
        {
            HeadClothing clothing = headClothing[id];

            if (CurrencyManager.instance.CurrencyCount >= clothing.Price)
            {
                if (CurrencyManager.instance.UpgradeCurrencyCount(-clothing.Price))
                {
                    CharacterManager.instance.characterInventory.AddHeadClothing(clothing);
                }
            }
        }
    }

    public void PurchaseBodyClothing(int id)
    {
        if (id < bodyClothing.Length)
        {
            BodyClothing clothing = bodyClothing[id];

            if (CurrencyManager.instance.CurrencyCount >= clothing.Price)
            {
                if (CurrencyManager.instance.UpgradeCurrencyCount(-clothing.Price))
                {
                    CharacterManager.instance.characterInventory.AddBodyClothing(clothing);
                }
            }
        }
    }
}
