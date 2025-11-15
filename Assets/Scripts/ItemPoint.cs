using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    public Item itemNeeded;
    public GameObject manager;

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
        manager.GetComponent<ChessPuzzle>().UseItem(item);
        if (item.itemID == itemNeeded.itemID)
        {
            Inventory.Instance.RemoveItem(item);
            item.isInCorrectPosition = true;
            Debug.Log("Item used here");
        }
        else
            Debug.Log("cant use that here");
    }
}
