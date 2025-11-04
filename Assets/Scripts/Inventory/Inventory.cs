using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    InventoryUIManager uiManager;
    List<Item> items;
    Item selectedItem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        uiManager = GetComponent<InventoryUIManager>();
        AddItem(selectedItem);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        uiManager.AddItem(item);
        Debug.Log("Item Added to Inventory");
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        uiManager.RemoveItem(item);
        Debug.Log("Item Removed from Inventory");
    }
    public void SelectItem(Item item)
    {
        uiManager.SelectItem(item);
        selectedItem = item;
        Debug.Log("Item Selected: " + item.itemName);
    }
}
