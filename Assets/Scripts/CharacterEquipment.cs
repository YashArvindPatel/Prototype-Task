using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [Header("Front")]
    public SpriteRenderer frontBody;
    public SpriteRenderer frontHelmet;
    public SpriteRenderer frontArmL;
    public SpriteRenderer frontSleeveL;
    public SpriteRenderer frontHandL;
    public SpriteRenderer frontArmR;
    public SpriteRenderer frontSleeveR;
    public SpriteRenderer frontHandR;
    public SpriteRenderer frontLegL;
    public SpriteRenderer frontLegR;

    [Header("Right")]
    public SpriteRenderer rightBody;
    public SpriteRenderer rightHelmet;
    public SpriteRenderer rightArmL;
    public SpriteRenderer rightHandL;
    public SpriteRenderer rightFingersR;
    public SpriteRenderer rightArmR;
    public SpriteRenderer rightSleeveL;
    public SpriteRenderer rightHandR;
    public SpriteRenderer rightLegL;
    public SpriteRenderer rightLegR;

    [Header("Back")]
    public SpriteRenderer backBody;
    public SpriteRenderer backHelmet;
    public SpriteRenderer backArmL;
    public SpriteRenderer backHandL;
    public SpriteRenderer backFingersL;
    public SpriteRenderer backArmR;
    public SpriteRenderer backHandR;
    public SpriteRenderer backFingersR;
    public SpriteRenderer backLegL;
    public SpriteRenderer backLegR;

    [Header("Left")]
    public SpriteRenderer leftBody;
    public SpriteRenderer leftHelmet;
    public SpriteRenderer leftArmR;
    public SpriteRenderer leftHandR;
    public SpriteRenderer leftFingersR;
    public SpriteRenderer leftArmL;
    public SpriteRenderer leftSleeveL;
    public SpriteRenderer leftHandL;
    public SpriteRenderer leftLegR;
    public SpriteRenderer leftLegL;

    public HeadClothing currentHeadClothing;
    public BodyClothing currentBodyClothing;

    public bool CheckIfHeadClothingEquipped(HeadClothing clothing)
    {
        return currentHeadClothing == clothing;
    }

    public bool CheckIfBodyClothingEquipped(BodyClothing clothing)
    {
        return currentBodyClothing == clothing;
    }

    public void EquipHelmet(HeadClothing clothing)
    {
        //Front
        frontHelmet.sprite = clothing.FrontHead;

        //Sides
        rightHelmet.sprite = leftHelmet.sprite = clothing.LeftHead;

        //Back
        backHelmet.sprite = clothing.BackHead;

        currentHeadClothing = clothing;
    }

    public void EquipBodyClothing(BodyClothing clothing)
    {
        //Front
        frontBody.sprite = clothing.FrontBody;
        frontArmL.sprite = clothing.FrontArmL;
        frontSleeveL.sprite = clothing.FrontSleeveL;
        frontHandL.sprite = clothing.FrontHandL;
        frontArmR.sprite = clothing.FrontArmR;
        frontSleeveR.sprite = clothing.FrontSleeveR;
        frontHandR.sprite = clothing.FrontHandR;
        frontLegL.sprite = clothing.FrontLegL;
        frontLegR.sprite = clothing.FrontLegR;

        //Sides
        rightBody.sprite = leftBody.sprite = clothing.LeftBody;
        rightArmL.sprite = leftArmL.sprite = clothing.LeftArmL;
        rightHandL.sprite = leftHandL.sprite = clothing.LeftHandL;
        rightFingersR.sprite = leftFingersR.sprite = clothing.LeftFingersR;
        rightArmR.sprite = leftArmR.sprite = clothing.LeftArmR;
        rightSleeveL.sprite = leftSleeveL.sprite = clothing.LeftSleeveL;
        rightHandR.sprite = leftHandR.sprite = clothing.LeftHandR;
        rightLegL.sprite = leftLegL.sprite = clothing.LeftLegL;
        rightLegR.sprite = leftLegR.sprite = clothing.LeftLegR;

        //Back
        backBody.sprite = clothing.BackBody;
        backArmL.sprite = clothing.BackArmL;
        backHandL.sprite = clothing.BackHandL;
        backFingersL.sprite = clothing.BackFingersL;
        backArmR.sprite = clothing.BackArmR;
        backHandR.sprite = clothing.BackHandR;
        backFingersR.sprite = clothing.BackFingersR;
        backLegL.sprite = clothing.BackLegL;
        backLegR.sprite = clothing.BackLegR;

        currentBodyClothing = clothing;
    }
}
