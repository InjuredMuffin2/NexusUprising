using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Inventory/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;
    /*
    
    public Item GetItemByID(int id)
    {
        // Implement logic to return the item with the specified ID
    }

    */
}
