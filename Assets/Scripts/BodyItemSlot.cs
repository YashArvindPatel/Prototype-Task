using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyItemSlot : MonoBehaviour
{
    //Private Readonly Variables
    private readonly string icon = "Icon";
    private readonly string sellIcon = "Sell Icon";

    //Public Variable
    public BodyClothing bodyClothing;

    void Start()
    {
        transform.Find(icon).GetComponent<Image>().sprite = bodyClothing.BodyIcon;

        //On Click Events added to Button Components for Item Slot
        transform.Find(sellIcon).GetComponent<Button>().onClick.AddListener(SellClothing);
        GetComponent<Button>().onClick.AddListener(EquipClothing);
    }

    public void EquipClothing()
    {
        CharacterManager.instance.characterEquipment.EquipBodyClothing(bodyClothing);
    }

    //Check if Character has the Clothing equipped or not, if not then sell clothing and add currency to balance
    public void SellClothing()
    {
        if (CharacterManager.instance.characterEquipment.CheckIfBodyClothingEquipped(bodyClothing))
        {
            AudioManager.instance.PlaySingleClip((int)SoundIndexes.ERROR);

            return;
        }
            
        CurrencyManager.instance.UpdateCurrencyCount(bodyClothing.Price);
        CharacterManager.instance.characterInventory.RemoveBodyClothing(bodyClothing);
        Destroy(gameObject);
    }
}
