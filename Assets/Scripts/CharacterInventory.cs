using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    private List<HeadClothing> ownedHeadClothing;
    private List<BodyClothing> ownedBodyClothing;

    public GameObject inventoryPanel;
    public GameObject equipmentPanel;
    public GameObject itemSlot;

    public GameObject changeRoomInteraction;

    void Start()
    {
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
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
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

    public void AddHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        HeadItemSlot headItemSlot = newItemSlot.AddComponent<HeadItemSlot>();
        headItemSlot.headClothing = clothing;

    }

    public void AddBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        BodyItemSlot bodyItemSlot = newItemSlot.AddComponent<BodyItemSlot>();
        bodyItemSlot.bodyClothing = clothing;
    }

    public void RemoveHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Remove(clothing);
    }

    public void RemoveBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Remove(clothing);
    }
}
