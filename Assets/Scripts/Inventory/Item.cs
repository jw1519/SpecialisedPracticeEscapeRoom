using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public Sprite itemIcon;
    public GameObject itemPrefab;

    private void OnMouseDown()
    {
        //put item in invent
        Debug.Log("Item picked up");
        Inventory.Instance.AddItem(this);
        Destroy(gameObject);
    }
}
