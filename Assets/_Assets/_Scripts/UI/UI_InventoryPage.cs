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

    public void initializeInventoryUI(int inventorySize){
        for (int i = 0; i < inventorySize; i++){
            UI_InventoryItem item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);

        }
    }
    
}
