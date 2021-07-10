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

    public void AddHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        HeadItemSlot headItemSlot = newItemSlot.AddComponent<HeadItemSlot>();
        headItemSlot.headClothing = clothing;

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    public void AddBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Add(clothing);

        GameObject newItemSlot = Instantiate(itemSlot, equipmentPanel.transform);
        BodyItemSlot bodyItemSlot = newItemSlot.AddComponent<BodyItemSlot>();
        bodyItemSlot.bodyClothing = clothing;

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    public void RemoveHeadClothing(HeadClothing clothing)
    {
        ownedHeadClothing.Remove(clothing);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }

    public void RemoveBodyClothing(BodyClothing clothing)
    {
        ownedBodyClothing.Remove(clothing);

        AudioManager.instance.PlaySingleClip((int)SoundIndexes.BUY_OR_SELL);
    }
}
