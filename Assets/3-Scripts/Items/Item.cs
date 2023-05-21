using UnityEngine;
using NexusUprising.Enumerators;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // ID is a number displaying the following properties of an item: rarity (1 to 7),
    public int id;
    public string itemName;
    public ItemCategory itemCategory;
    public ItemRarity itemRarity;
    public Sprite itemSprite;
    public int maxStackSize;
    public bool isStackable;


    public bool equippable;
    // Add a field for the stats that the item modifies, e.g., attack, defense, etc.
    public int attackModifier;
    public int defenseModifier;

    // Add other properties as needed
}

