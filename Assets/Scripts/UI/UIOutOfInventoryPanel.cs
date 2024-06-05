using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIOutOfInventoryPanel : MonoBehaviour, IDropHandler
{
    [SerializeField] private UIInventoryManager inventoryManager;
    [SerializeField] private InventorySO playerInventory;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {

        foreach (Slot slot in playerInventory.inventorySlots)
        {
            if (slot.item == eventData.pointerDrag.gameObject.GetComponent<UIInventoryItem>().item)
            {
                Instantiate(slot.item.itemPrefab, playerController.transform.position + new Vector3(0,.5f,0) + new Vector3(0,0,.5f), playerController.transform.rotation);
                break;
            }
        }

        Destroy(eventData.pointerDrag);
        inventoryManager.UpdateInventoryForUI();
    }
}
