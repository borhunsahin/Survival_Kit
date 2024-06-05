using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] private InventorySO playerInventory;
    [SerializeField] private UIInventoryManager uiInventoryManager;

    public BuildableObjects buildableObjects;
    public ItemsNeedForBuild itemsNeedForBuild;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void BuildCampFireButton()
    {
        BuildSO campFire = buildableObjects.campFire.GetComponent<Builder>().buildSO;
        
        if(campFire is BuildSO buildCampFire)
            BuildObject(buildableObjects.campFire, 
                itemsNeedForBuild.stone, buildCampFire.stoneCount, 
                itemsNeedForBuild.stick, buildCampFire.stickCount);

        playerController.player.isTabMenu = false;
        playerController.player.isActionMode = true;
    }

    public void BuildObject(GameObject buildableObject, GameObject needItem_1, int needItemCount_1, GameObject needItem_2, int needItemCount_2)
    {
        int item_1 = playerInventory.GetInventoryItemQuantity(needItem_1);
        int item_2 = playerInventory.GetInventoryItemQuantity(needItem_2);
        Debug.Log(item_1 >= needItemCount_1 && item_2 >= needItemCount_2);
        if (item_1 >= needItemCount_1 && item_2 >= needItemCount_2)
        {
            Instantiate(buildableObject, buildableObject.transform.position, buildableObject.transform.rotation);

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
public struct BuildableObjects
{
    public GameObject campFire;
}
[Serializable]
public struct ItemsNeedForBuild
{
    public GameObject stick;
    public GameObject stone;
    public GameObject wood;
    public GameObject timber;
}
