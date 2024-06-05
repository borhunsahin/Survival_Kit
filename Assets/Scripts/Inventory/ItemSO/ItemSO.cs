using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [Header("ItemInfo")]
    [SerializeField] protected new string name;
    [SerializeField] protected string description;
    [SerializeField] public GameObject itemPrefab;
    [Header("UI")]
    [SerializeField] public Sprite image;
    [Header("Status")]
    [SerializeField] public bool isStackable;
    [SerializeField] public bool isCraftable;
    [Header("ItemType")]

    [HideInInspector] public ItemType itemType;
}
public enum ItemType
{
    Tool,
    Craft,
    Food,
    Weapon
}



