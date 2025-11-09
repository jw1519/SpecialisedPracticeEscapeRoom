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
        //put item in invent
        Debug.Log("Item picked up");
        Inventory.Instance.AddItem(itemSO);
        Destroy(gameObject);
    }
}
