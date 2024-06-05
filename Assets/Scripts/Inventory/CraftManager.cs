using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private InventorySO playerInventory;
    [SerializeField] private UIInventoryManager uiInventoryManager;
    private PlayerController playerController;

    public CraftableItems craftableItems;
    public ItemsNeedForCraft itemsNeedForCraft;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void CraftStoneAxeButton()
    {
        ItemSO stoneAxe = craftableItems.stoneAxe.GetComponent<Item>().itemSO; // Kod tekrarı
        if (stoneAxe is ToolSO craftStoneAxe)
            CraftItem(craftableItems.stoneAxe,
                itemsNeedForCraft.stick, craftStoneAxe.stickCount,
                itemsNeedForCraft.stone, craftStoneAxe.stoneCount);
    }
    public void CraftStoneSpearButton()
    {
        ItemSO stoneSpear = craftableItems.stoneSpear.GetComponent<Item>().itemSO;
        if (stoneSpear is WeaponSO craftStoneSpear)
            CraftItem(craftableItems.stoneSpear,
                itemsNeedForCraft.wood, craftStoneSpear.woodCount,
                itemsNeedForCraft.stone, craftStoneSpear.stoneCount);
    }
    public void CraftWoodBatButton()
    {
        ItemSO woodBat = craftableItems.woodBat.GetComponent<Item>().itemSO;
        if (woodBat is WeaponSO craftWoodBat)
            CraftItem(craftableItems.woodBat,
                itemsNeedForCraft.wood, craftWoodBat.woodCount,
                itemsNeedForCraft.stone, craftWoodBat.stoneCount);
    }
    public void CraftTimberButton()
    {
        ItemSO timber = craftableItems.timber.GetComponent<Item>().itemSO;
        if (timber is CraftSO craftTimber)
            CraftItem(craftableItems.timber,
                itemsNeedForCraft.wood, craftTimber.woodCount);
    }
    public void CraftBeamButton()
    {
        ItemSO beam = craftableItems.beam.GetComponent<Item>().itemSO;
        if (beam is CraftSO craftBeam)
            CraftItem(craftableItems.beam,
                itemsNeedForCraft.wood, craftBeam.woodCount);
    }
    public void CraftItem(GameObject craftableItem, GameObject needItem_1, int needItemCount_1)
    {
        int item_1 = playerInventory.GetInventoryItemQuantity(needItem_1);

        if (item_1 >= needItemCount_1)
        {
            Instantiate(craftableItem, playerController.transform.position, craftableItem.transform.rotation);

            for (int i = 0; i < needItemCount_1; i++)
            {
                playerInventory.DeleteItem(needItem_1.GetComponent<Item>().itemSO, -1);
            }
        }
        uiInventoryManager.UpdateUIForInventory();
    }
    public void CraftItem(GameObject craftableItem, GameObject needItem_1, int needItemCount_1, GameObject needItem_2, int needItemCount_2)
    {
        int item_1 = playerInventory.GetInventoryItemQuantity(needItem_1);
        int item_2 = playerInventory.GetInventoryItemQuantity(needItem_2);

        if (item_1 >= needItemCount_1 && item_2 >= needItemCount_2)
        {
            Instantiate(craftableItem, playerController.transform.position, craftableItem.transform.rotation);

            for (int i = 0; i < needItemCount_1; i++)
            {
                playerInventory.DeleteItem(needItem_1.GetComponent<Item>().itemSO, -1);
            }
            for (int i = 0; i < needItemCount_2; i++)
            {
                playerInventory.DeleteItem(needItem_2.GetComponent<Item>().itemSO, -1);
            }
        }
        uiInventoryManager.UpdateUIForInventory();
    }
    
}
[Serializable]
public struct CraftableItems
{
    public GameObject stoneAxe;
    public GameObject stoneSpear;
    public GameObject woodBat;
    public GameObject timber;
    public GameObject beam;
}
[Serializable]
public struct ItemsNeedForCraft
{
    public GameObject stick;
    public GameObject stone;
    public GameObject wood;
}