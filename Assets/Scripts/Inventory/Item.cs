using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour,IHoldable,ICollectable
{
    PlayerController playerController;

    public ItemSO itemSO;
    

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void TakeOnHand(ItemSO item)
    {
        foreach (GameObject holdableObject in playerController.player.holdableObjects)
        {
            if (holdableObject.GetComponent<Item>().itemSO == item)
            {
                playerController.player.isFullHand = true;
                playerController.player.inHandObject = holdableObject;
                holdableObject.SetActive(true);
                playerController.playerInventory.AddItem(gameObject.GetComponent<Item>().itemSO, -1);
                playerController.uiInventoryManager.UpdateUIForInventory();
            }
        }
        Destroy(gameObject);
    }
    public void Collect(ItemSO item)
    {
        playerController.playerInventory.AddItem(item, -1);
        playerController.uiInventoryManager.UpdateUIForInventory();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagableObject) && playerController.player.isFullHand && itemSO.itemType == ItemType.Tool)
        {
            damagableObject.Damage(25); // Axe ın damagesi alınamıyor.
        }
    }
}