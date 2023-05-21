using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    public int initialSlots;

    private void Awake()
    {
        // Initialize the item slots with empty slots
        for (int i = 0; i < initialSlots; i++)
        {
            itemSlots.Add(new ItemSlot());
        }
    }

    public void AddItem(Item item)
    {
        // Implement logic to add an item to the appropriate slot
    }

    public void RemoveItem(Item item)
    {
        // Implement logic to remove an item from the appropriate slot
    }

    public void ExpandInventory(int additionalSlots)
    {
        for (int i = 0; i < additionalSlots; i++)
        {
            itemSlots.Add(new ItemSlot());
        }
    }
}
