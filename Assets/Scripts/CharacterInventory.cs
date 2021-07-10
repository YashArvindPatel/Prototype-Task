using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    //Private variables to store Owned Clothing 
    private List<HeadClothing> ownedHeadClothing;
    private List<BodyClothing> ownedBodyClothing;

    //Public Variables
    public GameObject inventoryPanel;
    public GameObject equipmentPanel;
    public GameObject itemSlot;
    public GameObject changeRoomInteraction;

    void Start()
    {
        //Initalize the Lists for storing Clothing Data
        ownedHeadClothing = new List<HeadClothing>();
        ownedBodyClothing = new List<BodyClothing>();
    }

    public bool CheckIfHeadClothingOwned(HeadClothing clothing)
    {
        return ownedHeadClothing.Contains(clothing);
    }

    public bool CheckIfBodyClothingOwned(BodyClothing clothing)
    {
        return ownedBodyClothing.Contains(clothing);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        HideInteraction();

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.OPEN);
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.CLOSE);
    }

    public void ShowInteraction()
    {
        if (!inventoryPanel.activeSelf && !Shop.instance.catalog.activeSelf)
            changeRoomInteraction.SetActive(true);
    }

    public void HideInteraction()
    {
        changeRoomInteraction.SetActive(false);
    }

    //Add Head Clothing to List and instantiate corresponding Item Slot to hold Clothing Info
    public void AddHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        HeadItemSlot headItemSlot = newItemSlot.AddComponent<HeadItemSlot>();
        headItemSlot.headClothing = clothing;

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    //Add Body Clothing to List and instantiate corresponding Item Slot to hold Clothing Info
    public void AddBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        BodyItemSlot bodyItemSlot = newItemSlot.AddComponent<BodyItemSlot>();
        bodyItemSlot.bodyClothing = clothing;

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    //Remove Head Clothing from the List, the corresponding Item Slot GameObject is destroyed 
    public void RemoveHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Remove(clothing);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    //Remove Body Clothing from the List, the corresponding Item Slot GameObject is destroyed 
    public void RemoveBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Remove(clothing);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }
}
