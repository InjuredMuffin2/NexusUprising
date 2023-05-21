using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NexusUprising.Enumerators;

public class EquipmentSlot : MonoBehaviour
{
    public Item item;
    public ItemCategory allowedItemType;

    public void SetItem(Item newItem, int newStackSize)
    {
        //foreach()
        if(newItem.itemCategory == allowedItemType)
        item = newItem;
    }

    public void ClearSlot()
    {
        item = null;
    }
}
