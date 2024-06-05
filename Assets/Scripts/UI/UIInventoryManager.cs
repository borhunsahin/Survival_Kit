using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    public List<UIInventorySlot> uiInventorySlots = new List<UIInventorySlot>();
    [SerializeField] private InventorySO playerInventory;

    public GameObject inventoryItemObject;
    public void Start()
    {
        UpdateUIForInventory();
    }
    public void UpdateUIForInventory()
    {
        ItemSO inventoryItem;
        UIInventoryItem uIInventoryItem;

        for (int i = 0; i < playerInventory.inventorySlots.Count; i++)
        {
            inventoryItem = playerInventory.inventorySlots[i].item;
            uIInventoryItem = uiInventorySlots[i].GetComponentInChildren<UIInventoryItem>();

            if (inventoryItem != null && uIInventoryItem == null)
            {
                AddUIInventoryItem(inventoryItemObject, inventoryItem,i);
            }
            else if(inventoryItem == null && uIInventoryItem != null)
            {
                Destroy(uIInventoryItem.gameObject);
            }
        }
    }
    public void UpdateInventoryForUI()
    {
        ItemSO inventoryItem;
        UIInventoryItem uiInventoryItem;

        for (int i = 0;i < uiInventorySlots.Count;i++)
        {
            uiInventoryItem = uiInventorySlots[i].GetComponentInChildren<UIInventoryItem>();
            inventoryItem = playerInventory.inventorySlots[i].item;
            if (uiInventoryItem == null && inventoryItem != null)
            {
                playerInventory.DeleteItem(inventoryItem,i);
            }
            else if(uiInventoryItem != null && inventoryItem == null)
            {
                playerInventory.AddItem(uiInventoryItem.item,i);
            }
        }
    }
    public bool AddUIInventoryItem(GameObject inventoryItemObject, ItemSO item,int index)
    {
        UIInventorySlot uiInventorySlot;
        UIInventoryItem uiInventoryItem;

        for (int i = 0; i < playerInventory.inventorySlots.Count; i++)
        {
            uiInventorySlot = uiInventorySlots[index];
            uiInventoryItem = uiInventorySlot.GetComponentInChildren<UIInventoryItem>();

            if(uiInventoryItem == null)
            {
                inventoryItemObject.GetComponent<UIInventoryItem>().item = item;
                Instantiate(inventoryItemObject, uiInventorySlot.transform);
                return true;
            } 
        }
        return false;
    }
}
