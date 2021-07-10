﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public readonly string tag1 = "ChangeRoom";
    public readonly string tag2 = "Shopkeeper";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag1))
        {
            CharacterManager.instance.characterInventory.ShowInteraction();
        }
        else if (collision.CompareTag(tag2))
        {
            Shop.instance.ShowInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag1))
        {
            CharacterManager.instance.characterInventory.HideInteraction();
        }
        else if (collision.CompareTag(tag2))
        {
            Shop.instance.HideInteraction();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CharacterManager.instance.characterInventory.changeRoomInteraction.activeSelf)
            {
                CharacterManager.instance.characterInventory.OpenInventory();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Shop.instance.shopKeeperInteraction.activeSelf)
            {
                Shop.instance.OpenCatalog();
            }
        }
    }
}
