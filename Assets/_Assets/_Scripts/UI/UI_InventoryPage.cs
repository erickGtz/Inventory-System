using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script control everything related to inventory slots, 
item display and item actions.
It will be attached to the inventory panel which will be instantiated 
and added to the canvas when the inventory is opened
*/

public class UI_InventoryPage : MonoBehaviour
{
    [SerializeField]
    private UI_InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;
    [SerializeField]
    private UI_InventoryDescription itemDescription;
    [SerializeField]
    private MouseFollower mouseFollower;

    List<UI_InventoryItem> listUI_Items = new List<UI_InventoryItem>();
    private int currentlyDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested, OnItemActionRequested,
    OnStartDragging;

    public event Action<int, int> OnSwapItems;


    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }

    public void initializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UI_InventoryItem item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(contentPanel);
            listUI_Items.Add(item);
            item.OnItemClicked += HandleItemSelection;
            item.OnRightMouseBtnClick += HandleShowItemActions;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemEndDrag += HandleEndDrag;
            item.OnItemDroppedOn += HandleSwap;
        }
    }

    private void HandleSwap(UI_InventoryItem item)
    {
        int index = listUI_Items.IndexOf(item);
        if (index == -1)
        {

            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleEndDrag(UI_InventoryItem item)
    {
        ResetDraggedItem();
    }

    private void HandleBeginDrag(UI_InventoryItem item)
    {
        int index = listUI_Items.IndexOf(item);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(item);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        mouseFollower.SetData(sprite, quantity);
        mouseFollower.Toggle(true);
    }

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if (listUI_Items.Count < itemIndex)
        {
            listUI_Items[itemIndex].SetData(itemImage, itemQuantity);
        }
    }

    private void HandleShowItemActions(UI_InventoryItem item)
    {

    }

    private void HandleItemSelection(UI_InventoryItem item)
    {
        int index = listUI_Items.IndexOf(item);
        if (index == -1)
        {
            return;
        }
        OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
    }

    private void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach (UI_InventoryItem item in listUI_Items)
        {
            item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
        ResetSelection();
    }

}
