using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject dropped = eventData.pointerDrag;
            UIInventoryItem inventoryItem = dropped.GetComponent<UIInventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
