using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject itemContainer;
    public GameObject inventoryContainer;
    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }
    public void AddItem(Item item)
    {
        GameObject itemContainer = Instantiate(this.itemContainer, inventoryContainer.transform);
        //itemContainer.transform.parent = inventoryContainer.transform;

        //set item icon and name
        Image itemImage = itemContainer.GetComponent<Image>();
        itemImage.sprite = item.itemIcon;
        itemContainer.name = item.itemID;

        //add button listener
        Button itemButton = itemContainer.GetComponent<Button>();
        itemButton.onClick.AddListener(() => Inventory.Instance.SelectItem(item));
    }
    public void RemoveItem(Item item)
    {
        foreach (RectTransform child in inventoryContainer.transform)
        {
            Debug.Log(item.itemName);
            if (child.name == item.itemID)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
    public void SelectItem(Item item)
    {
        Debug.Log("Item Selected in UI: " + item.itemName);
        //change background color of selected item
    }
}
