using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UI_InventoryPage inventoryPage;
    private bool inventoryState;

    public int inventorySize = 10;

    private void Start()
    {
        inventoryPage.initializeInventoryUI(inventorySize);
        inventoryPage.Hide();
        inventoryState = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryState = !inventoryState;
            if (inventoryState)
                inventoryPage.Show();
            else
                inventoryPage.Hide();
        }
    }
}
