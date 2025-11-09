using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemID;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(itemID))
        {
            //create unique id for item
            itemID = itemName + "-" + System.Guid.NewGuid().ToString();
        }
    }
    public virtual void SelectItem()
    {
        Inventory.Instance.SelectItem(this);
    }
}
