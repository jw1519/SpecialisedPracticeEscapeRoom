using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemID;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public bool isInCorrectPosition; 
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
    public virtual void UseItem()
    {
        
    }
    public virtual void PlaceItem(Vector3 spawn)
    {
        Instantiate(itemPrefab, spawn, Quaternion.identity);
    }
}
