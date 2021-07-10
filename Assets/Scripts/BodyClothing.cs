using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body Cloth", menuName = "Body Clothes")]
public class BodyClothing : ScriptableObject
{
    //Icon
    public Sprite BodyIcon;

    //Front
    public Sprite FrontBody;
    public Sprite FrontArmL;
    public Sprite FrontSleeveL;
    public Sprite FrontHandL;
    public Sprite FrontArmR;
    public Sprite FrontSleeveR;
    public Sprite FrontHandR;
    public Sprite FrontLegL;
    public Sprite FrontLegR;

    //Sides
    public Sprite LeftBody;
    public Sprite LeftArmL;
    public Sprite LeftHandL;
    public Sprite LeftFingersR;
    public Sprite LeftArmR;
    public Sprite LeftSleeveL;
    public Sprite LeftHandR;
    public Sprite LeftLegL;
    public Sprite LeftLegR;

    //Back
    public Sprite BackBody;
    public Sprite BackArmL; 
    public Sprite BackHandL;
    public Sprite BackFingersL;
    public Sprite BackArmR;
    public Sprite BackHandR;
    public Sprite BackFingersR;
    public Sprite BackLegL;
    public Sprite BackLegR;

    //Private Variable
    [SerializeField]
    private int price;

    //Property
    public int Price { get { return price; } set { price = value; } }
}
