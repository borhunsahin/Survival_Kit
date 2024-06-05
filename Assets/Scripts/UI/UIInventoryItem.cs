using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected UIInventoryManager uiInventoryManager;

    [Header("UI")]
    public Image image;
    public Text countText;
    [HideInInspector] public int count = 1;
    [HideInInspector] public ItemSO item;

    [HideInInspector] public Transform parentAfterDrag;

    void Start()
    {
        uiInventoryManager = GameObject.Find("UIInventoryManager").GetComponent<UIInventoryManager>();

        InitialiseItem(item);
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    public void InitialiseItem(ItemSO newItem)
    {
        image.sprite = newItem.image;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        uiInventoryManager.UpdateInventoryForUI();
    }
}
