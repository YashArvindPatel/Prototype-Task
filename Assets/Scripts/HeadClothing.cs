using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Head Cloth", menuName = "Head Clothes")]
public class HeadClothing : ScriptableObject
{
    //Icon
    public Sprite HeadIcon;

    //Front
    public Sprite FrontHead;

    //Sides
    public Sprite LeftHead;

    //Back
    public Sprite BackHead;

    //Private Variable
    [SerializeField]
    private int price;

    //Property
    public int Price { get { return price; } set { price = value; } }
}
