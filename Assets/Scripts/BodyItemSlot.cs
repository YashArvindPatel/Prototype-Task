using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyItemSlot : MonoBehaviour
{
    private readonly string icon = "Icon";
    private readonly string sellIcon = "Sell Icon";

    public BodyClothing bodyClothing;

    void Start()
    {
        transform.Find(icon).GetComponent<Image>().sprite = bodyClothing.BodyIcon;
        transform.Find(sellIcon).GetComponent<Button>().onClick.AddListener(SellClothing);
        GetComponent<Button>().onClick.AddListener(EquipClothing);
    }

    public void EquipClothing()
    {
        CharacterManager.instance.characterEquipment.EquipBodyClothing(bodyClothing);
    }

    public void SellClothing()
    {
        if (CharacterManager.instance.characterEquipment.CheckIfBodyClothingEquipped(bodyClothing))
            return;

        CurrencyManager.instance.UpgradeCurrencyCount(bodyClothing.Price);
        CharacterManager.instance.characterInventory.RemoveBodyClothing(bodyClothing);
        Destroy(gameObject);
    }
}
