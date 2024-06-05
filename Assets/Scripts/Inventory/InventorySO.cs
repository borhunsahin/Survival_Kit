using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField] public List<Slot> inventorySlots = new List<Slot>();
    [SerializeField] private int stackLimit = 4;

    public bool AddItem(ItemSO item,int index)
    {
        if(index > -1 && index <= inventorySlots.Count)
        {
            Slot slot = inventorySlots[index];

            if (slot.item == item && slot.item.isStackable && slot.itemCount < stackLimit)
            {
                slot.itemCount++;
                if (slot.itemCount >= stackLimit)
                    slot.isFull = true;
                return true;
            }
            else if (slot.itemCount == 0)
            {
                slot.AddItemToSlot(item);
                return true;
            }
            return false;
        }
        else if(index == -1)
        {
            foreach (Slot slot in inventorySlots)
            {
                if (slot.item == item && slot.item.isStackable && slot.itemCount < stackLimit)
                {
                    slot.itemCount++;
                    if (slot.itemCount >= stackLimit)
                        slot.isFull = true;
                    return true;
                }
                else if (slot.itemCount == 0)
                {
                    slot.AddItemToSlot(item);
                    return true;
                }
            }
            return false;
        }
        else
        {
            Debug.Log("The AddItem() index variable must be equal to the number of slots or -1");
            return false;
        }
    }
    public bool DeleteItem(ItemSO item,int index)
    {
        if(index >-1 && index <= inventorySlots.Count)
        {
            Slot slot = inventorySlots[index];

            if (item == slot.item)
            {
                slot.item = null;
                slot.itemCount = 0;
                slot.isFull = false;

                return true;
            }
            return false;
        }
        else if(index == -1)
        {
            foreach(Slot slot in inventorySlots)
            {
                if (item == slot.item)
                {
                    slot.item = null;
                    slot.itemCount = 0;
                    slot.isFull = false;

                    return true;
                }
            }
            return false;
        }
        else
        {
            Debug.Log("The DeleteItem() index variable must be equal to the number of slots or -1");
            return false;
        }
    }
    public int GetInventoryItemQuantity(GameObject gameObject)
    {
        int result = 0;
        foreach (Slot slot in inventorySlots)
        {
            if(gameObject.GetComponent<Item>().itemSO == slot.item)
                result++;
        }
        return result;
    }
}
[Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public ItemSO item;

    public void AddItemToSlot(ItemSO item)
    {
        this.item = item;

        if (item.isStackable == false)
        {
            isFull = true;
        }
        itemCount++;
    }
}
