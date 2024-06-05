using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

[CreateAssetMenu(fileName = "ToolItem", menuName = "Scriptable/Tool")]
public class ToolSO : ItemSO
{
    public ToolItemType toolItemType;
    public int Damage;

    [Header("Item Needed For Crafting")]

    public int stoneCount;
    public int stickCount;
    public int woodCount;
    public int timberCount;
    public int beamCount;
    public enum ToolItemType
    {
        Axe
    }
}