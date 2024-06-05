using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponSO;

[CreateAssetMenu(fileName = "CraftItem", menuName = "Scriptable/Craft")]
public class CraftSO : ItemSO
{
    public CraftItemType craftItemType;

    [Header("Item Needed For Crafting")]

    public int stoneCount;
    public int stickCount;
    public int woodCount;
    public int timberCount;
    public int beamCount;
    public enum CraftItemType
    {
        Stone,
        Stick,
        Wood,
        Timber,
        Beam
    }
}

