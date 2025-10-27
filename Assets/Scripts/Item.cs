using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemID;
    private void OnMouseDown()
    {
        //put item in invent
        Debug.Log("Item picked up");
        Destroy(gameObject);
    }
}
