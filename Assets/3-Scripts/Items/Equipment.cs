using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public List<EquipmentSlot> equipmentSlots;

    public void EquipItem(Item item, EquipmentSlot equipmentSlot)
    {
        // Check if the item is equippable
        if (item.equippable && item.itemCategory == equipmentSlot.allowedItemType)
        {
            // Unequip the current item in the slot, if any
            //UnequipItem(slotIndex);

            // Equip the new item
            //equipmentSlots[slotIndex].SetItem(item, 1);

            // Update player stats (assuming you have a PlayerStats script)
            // Add the item's stat modifiers to the player's stats
            PlayerStats.Instance.attack += item.attackModifier;
            PlayerStats.Instance.defense += item.defenseModifier;

            // Update equipment UI
            // ...
        }
    }

    public void UnequipItem(int slotIndex)
    {
        // Check if the slot index is valid and the slot contains an item
        if (slotIndex >= 0 && slotIndex < equipmentSlots.Count && equipmentSlots[slotIndex].item != null)
        {
            // Get the item to be unequipped
            Item item = equipmentSlots[slotIndex].item;

            // Update player stats (assuming you have a PlayerStats script)
            // Remove the item's stat modifiers from the player's stats
            PlayerStats.Instance.attack -= item.attackModifier;
            PlayerStats.Instance.defense -= item.defenseModifier;

            // Remove the item from the equipped slot
            equipmentSlots[slotIndex].ClearSlot();

            // Update equipment UI
            // ...
        }
    }
}
