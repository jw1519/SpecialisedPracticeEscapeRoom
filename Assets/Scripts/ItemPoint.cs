using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    public Item itemNeeded;

    private void OnMouseDown()
    {
        Item item = Inventory.Instance.selectedItem;
        if (item != null)
        {
            UseItemOnPoint(item);
        }
    }
    public void UseItemOnPoint(Item item)
    {
        if (item.itemID == itemNeeded.itemID)
        {
            Inventory.Instance.RemoveItem(item);
            Debug.Log("Item used here");
        }
        else
            Debug.Log("cant use that here");
    }
}
