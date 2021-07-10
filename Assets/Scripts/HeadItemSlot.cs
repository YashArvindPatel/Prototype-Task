using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadItemSlot : MonoBehaviour
{
    private readonly string icon = "Icon";
    private readonly string sellIcon = "Sell Icon";

    public HeadClothing headClothing;

    void Start()
    {
        transform.Find(icon).GetComponent<Image>().sprite = headClothing.HeadIcon;
        transform.Find(sellIcon).GetComponent<Button>().onClick.AddListener(SellClothing);
        GetComponent<Button>().onClick.AddListener(EquipClothing);
    }

    public void EquipClothing()
    {
        CharacterManager.instance.characterEquipment.EquipHelmet(headClothing);
    }

    public void SellClothing()
    {
        if (CharacterManager.instance.characterEquipment.CheckIfHeadClothingEquipped(headClothing))
        {
            AudioManager.instance.PlaySingleClip((int)SoundIndexes.ERROR);

            return;
        }
            
        CurrencyManager.instance.UpgradeCurrencyCount(headClothing.Price);
        CharacterManager.instance.characterInventory.RemoveHeadClothing(headClothing);
        Destroy(gameObject);
    }
}
