using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryUI;

    public Equipment equipment;
    // Add reference to Equipment script if necessary

    public bool AddItem(Item item)
    {
        // Check if the item is stackable and there is an existing slot with the same item type
        if (item.isStackable)
        {
            foreach (ItemSlot itemSlot in inventory.itemSlots)
            {
                if (itemSlot.item != null && itemSlot.item == item && itemSlot.stackSize < item.maxStackSize)
                {
                    itemSlot.stackSize++;
                    return true;
                }
            }
        }

        // If the item is not stackable or there's no existing slot with the same item type, find an empty slot
        foreach (ItemSlot itemSlot in inventory.itemSlots)
        {
            if (itemSlot.item == null)
            {
                itemSlot.item = item;
                itemSlot.stackSize = 1;
                return true;
            }
        }

        // If there are no empty slots, return false to indicate that the item couldn't be added
        return false;
    }

    public void RemoveItem(Item item)
    {
        // Implement logic to remove item from the inventory
    }

    public void EquipItem(Item item)
    {
        // Implement logic to equip the item and remove it from the inventory
        // You might want to check if there's a suitable empty slot in the equipment before equipping the item

        /*
        
        int slotIndex  = equipment.FindEmptySlot();
        if (slotIndex >= 0)
        {
            equipment.EquipItem(item, slotIndex);
            inventory.RemoveItem(item);
            UpdateInventoryUI();
        }

        */
    }

    public void UnequipItem(int slotIndex)
    {
        // Implement logic to unequip the item and add it back to the inventory
        Item item = equipment.equipmentSlots[slotIndex].item;
        if (item != null)
        {
            equipment.UnequipItem(slotIndex);
            inventory.AddItem(item);
            UpdateInventoryUI();
        }
    }

    public void UpdateInventoryUI()
    {
        // Implement logic to update the inventory UI
    }
}