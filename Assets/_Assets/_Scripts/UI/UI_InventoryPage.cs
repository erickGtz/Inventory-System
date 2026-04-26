using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_InventoryPage : MonoBehaviour
{
    [SerializeField]
    private UI_InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;
    [SerializeField]
    private UI_InventoryDescription itemDescription;

    List<UI_InventoryItem> listUI_Items = new List<UI_InventoryItem>();

    public Sprite imageConversion;
    public int quantity;
    public string title, description;


    private void Awake()
    {
        Hide();
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
    }

    private void HandleBeginDrag(UI_InventoryItem item)
    {
    }

    private void HandleShowItemActions(UI_InventoryItem item)
    {
    }

    private void HandleItemSelection(UI_InventoryItem item)
    {
        itemDescription.SetDescription(imageConversion, title, description);
        listUI_Items[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        listUI_Items[0].SetData(imageConversion, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
