using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int stackSize;

    public void SetItem(Item newItem, int newStackSize)
    {
        item = newItem;
        stackSize = newStackSize;
    }

    public void ClearSlot()
    {
        item = null;
        stackSize = 0;
    }
}
