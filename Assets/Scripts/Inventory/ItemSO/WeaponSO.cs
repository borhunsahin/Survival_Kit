using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToolSO;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "Scriptable/Weapon")]
public class WeaponSO : ItemSO
{
    public WeaponItemType weaponItemType;
    public int Damage;

    [Header("Item Needed For Crafting")]

    public int stoneCount;
    public int stickCount;
    public int woodCount;
    public int timberCount;
    public int beamCount;
    public enum WeaponItemType
    {
        Axe,
        Bat,
        Spear
    }
}