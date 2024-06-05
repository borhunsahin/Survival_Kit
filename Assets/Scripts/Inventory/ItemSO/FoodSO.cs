using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Scriptable/Food")]
public class FoodSO : ItemSO
{
    public FoodItemType foodItemType;
    public enum FoodItemType
    {

    }
}
