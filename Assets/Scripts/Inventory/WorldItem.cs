using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public Item itemSO;

    private void Awake()
    {
        if (itemSO != null)
        {
           itemSO.itemPrefab = gameObject;
        }
    }
    private void OnMouseDown()
    {
        //pick up item
        Inventory.Instance.AddItem(itemSO);
        itemSO.isInCorrectPosition = false;
        Destroy(gameObject);
    }
}
