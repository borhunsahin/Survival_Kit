using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerController playerController;

    public InventorySO playerInventory;
    public UIInventoryManager uiInventoryManager;

    public GamePanel gamePanel;
    public UIPanels uiPanels;

    List<GameObject> tabPanelList;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        tabPanelList = new List<GameObject> 
        { 
            uiPanels.inventoryTabPanel,
            uiPanels.equipmentTabPanel,
            uiPanels.craftTabPanel,
            uiPanels.buildTabPanel,
            uiPanels.questTabPanel,
            uiPanels.mapTabPanel 
        };
    }
    void Update()
    {
        // Sürekli kontrol etmemeli
        gamePanel.dot.SetActive(playerController.player.isActionMode ? true : false);
        uiPanels.tabMenuCanvas.SetActive(playerController.player.isTabMenu ? true : false);
    }
    public void InventoryTabButton()
    {
        TabPanelSelecter(uiPanels.inventoryTabPanel);
    }
    public void EquipmentTabButton()
    {
        TabPanelSelecter(uiPanels.equipmentTabPanel);
    }
    public void CraftTabButton()
    {
        TabPanelSelecter(uiPanels.craftTabPanel);
    }
    public void BuildTabButton()
    {
        TabPanelSelecter(uiPanels.buildTabPanel);
    }
    public void QuestTabButton()
    {
        TabPanelSelecter(uiPanels.questTabPanel);
    }
    public void MapTabButton()
    {
        TabPanelSelecter(uiPanels.mapTabPanel);
    }
    public void TabPanelSelecter(GameObject activePanel)
    {
        foreach(GameObject tabPanel in tabPanelList) 
        {
            if(tabPanel == activePanel)
            {
                tabPanel.SetActive(true);
            }
            else
            {
                tabPanel.SetActive(false);
            }
        }
    }
}
[Serializable]
public struct GamePanel
{
    public GameObject dot;
}
[Serializable]
public struct UIPanels
{
    public GameObject tabMenuCanvas;

    public GameObject inventoryTabPanel;
    public GameObject equipmentTabPanel;
    public GameObject craftTabPanel;
    public GameObject buildTabPanel;
    public GameObject questTabPanel;
    public GameObject mapTabPanel;
}
