using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public readonly string tag1 = "ChangeRoom";
    public readonly string tag2 = "Shopkeeper";

    //Check if Player Collider enters within the range of an Interactable Object & trigger Interaction
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

    //Check if Player Collider exits from the range of an Interactable Object & close Interaction
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
        //Check if 'Q' Key is pressed and trigger Interaction if within range of an Interactable Object
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CharacterManager.instance.characterInventory.changeRoomInteraction.activeSelf)
            {
                CharacterManager.instance.characterInventory.OpenInventory();
            }
        }

        //Check if 'E' Key is pressed and trigger Interaction if within range of an Interactable Object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Shop.instance.shopKeeperInteraction.activeSelf)
            {
                Shop.instance.OpenCatalog();
            }
        }
    }
}
