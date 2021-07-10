using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadItemSlot : MonoBehaviour
{
    //Private Readonly Variables
    private readonly string icon = "Icon";
    private readonly string sellIcon = "Sell Icon";

    //Public Variable
    public HeadClothing headClothing;

    void Start()
    {
        transform.Find(icon).GetComponent<Image>().sprite = headClothing.HeadIcon;

        //On Click Events added to Button Components for Item Slot
        transform.Find(sellIcon).GetComponent<Button>().onClick.AddListener(SellClothing);
        GetComponent<Button>().onClick.AddListener(EquipClothing);
    }

    public void EquipClothing()
    {
        CharacterManager.instance.characterEquipment.EquipHelmet(headClothing);
    }

    //Check if Character has the Clothing equipped or not, if not then sell clothing and add currency to balance
    public void SellClothing()
    {
        if (CharacterManager.instance.characterEquipment.CheckIfHeadClothingEquipped(headClothing))
        {
            AudioManager.instance.PlaySingleClip((int)SoundIndexes.ERROR);

            return;
        }
            
        CurrencyManager.instance.UpdateCurrencyCount(headClothing.Price);
        CharacterManager.instance.characterInventory.RemoveHeadClothing(headClothing);
        Destroy(gameObject);
    }
}
