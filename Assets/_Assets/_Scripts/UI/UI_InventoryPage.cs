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

    public Sprite image;
    public int quantity;
    public string title, description;


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

    }

    private void HandleEndDrag(UI_InventoryItem item)
    {
        mouseFollower.Toggle(false);
    }

    private void HandleBeginDrag(UI_InventoryItem item)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity);
    }

    private void HandleShowItemActions(UI_InventoryItem item)
    {
    }

    private void HandleItemSelection(UI_InventoryItem item)
    {
        itemDescription.SetDescription(image, title, description);
        listUI_Items[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        listUI_Items[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
