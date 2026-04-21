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

    List<UI_InventoryItem> listUI_Items = new List<UI_InventoryItem>();

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
        Debug.Log("Item selected: " + item.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
