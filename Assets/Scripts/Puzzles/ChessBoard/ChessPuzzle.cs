using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{
    public List<Item> chessPieces;
    public List<ItemPoint> itemPoints;

    // Check if all chess pieces are in their correct positions
    public bool IsPuzzleSolved()
    {
        foreach (var piece in chessPieces)
        {
            if (!piece.isInCorrectPosition)
            {
                return false;
            }
        }
        return true;
    }
    public void UseItem(Item item)
    {
        foreach (var piece in chessPieces)
        {
            if (piece.itemID == item.itemID)
            {
                Inventory.Instance.RemoveItem(item);
                item.PlaceItem(itemPoints.Find(itemPoint => item == itemPoint.itemNeeded).transform.position);
                Debug.Log("Placed " + piece.itemName + " in correct position.");
                return;
            }
            
        }
        Debug.Log("This item does not belong to the chess puzzle.");
    }
}
