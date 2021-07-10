using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //Singleton of CharacterManager
    public static CharacterManager instance;

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

    public CharacterInventory characterInventory;
    public CharacterEquipment characterEquipment;
}
