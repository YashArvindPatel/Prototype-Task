using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Singleton of Shop
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

    //Public Variables
    public HeadClothing[] headClothing;
    public BodyClothing[] bodyClothing;

    public GameObject catalog;
    public Image catalogPage;
    public GameObject shopKeeperInteraction;

    public GameObject[] pages;

    //Private Variables
    private Color[] pageColors;
    private int currentPageIndex = 0;

    void Start()
    {
        //Parse Hexadecimal value of Color and store in pageColors array
        ColorUtility.TryParseHtmlString("#89C1F5", out Color color1);
        ColorUtility.TryParseHtmlString("#B2694E", out Color color2);
        ColorUtility.TryParseHtmlString("#FAF94A", out Color color3);
        ColorUtility.TryParseHtmlString("#FFB3F2", out Color color4);
        ColorUtility.TryParseHtmlString("#F57B7D", out Color color5);
        ColorUtility.TryParseHtmlString("#88F57C", out Color color6);
        ColorUtility.TryParseHtmlString("#707575", out Color color7);
        ColorUtility.TryParseHtmlString("#E8FCFC", out Color color8);
        ColorUtility.TryParseHtmlString("#DAA1E2", out Color color9);

        pageColors = new Color[9] { color1, color2, color3, color4, color5, color6, color7, color8, color9 };
    }

    public void OpenCatalog()
    {
        catalog.SetActive(true);
        HideInteraction();

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.OPEN);
    }

    public void CloseCatalog()
    {
        catalog.SetActive(false);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.CLOSE);
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

    //Check if the Catalog page is the leftmost or not, close Catalog if it is or instead open left page
    public void TurnCatalogPageLeft()
    {
        if (currentPageIndex == 0)
        {
            CloseCatalog();
        }
        else
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex -= 1;
            catalogPage.color = pageColors[currentPageIndex];
            pages[currentPageIndex].SetActive(true);

            AudioManager.instance.PlaySingleClip((int)SoundIndexes.SELECT);
        }
    }

    //Check if the Catalog page is the rightmost or not, close Catalog if it is or instead open right page
    public void TurnCatalogPageRight()
    {
        if (currentPageIndex == pages.Length - 1)
        {
            CloseCatalog();
        }
        else
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex += 1;
            catalogPage.color = pageColors[currentPageIndex];
            pages[currentPageIndex].SetActive(true);

            AudioManager.instance.PlaySingleClip((int)SoundIndexes.SELECT);
        }
    }

    public void PurchaseHeadClothing(int id)
    {
        //Check if given id is within the range of the headClothing array 
        if (id < headClothing.Length)
        {
            HeadClothing clothing = headClothing[id];

            //Check if piece of clothing is already purchased & if there are enough coins to purchase the clothing
            if (!CharacterManager.instance.characterInventory.CheckIfHeadClothingOwned(clothing) && CurrencyManager.instance.CurrencyCount >= clothing.Price)
            {
                if (CurrencyManager.instance.UpdateCurrencyCount(-clothing.Price))
                {
                    CharacterManager.instance.characterInventory.AddHeadClothing(clothing);
                }
            }
            else
            {
                AudioManager.instance.PlaySingleClip((int)SoundIndexes.ERROR);
            }
        }
    }

    public void PurchaseBodyClothing(int id)
    {
        //Check if given id is within the range of the headClothing array 
        if (id < bodyClothing.Length)
        {
            BodyClothing clothing = bodyClothing[id];

            //Check if piece of clothing is already purchased & if there are enough coins to purchase the clothing
            if (!CharacterManager.instance.characterInventory.CheckIfBodyClothingOwned(clothing) && CurrencyManager.instance.CurrencyCount >= clothing.Price)
            {
                if (CurrencyManager.instance.UpdateCurrencyCount(-clothing.Price))
                {
                    CharacterManager.instance.characterInventory.AddBodyClothing(clothing);
                }
            }
            else
            {
                AudioManager.instance.PlaySingleClip((int)SoundIndexes.ERROR);
            }
        }
    }
}
