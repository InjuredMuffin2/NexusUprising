using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject inventoryUI;
    public GameObject itemSlotPrefab;
    public Transform itemSlotContainer;

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // Remove all current item slot UI elements
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        // Create new item slot UI elements for each item slot in the inventory
        foreach (ItemSlot itemSlot in inventoryManager.inventory.itemSlots)
        {
            GameObject newItemSlotUI = Instantiate(itemSlotPrefab, itemSlotContainer);
            ItemSlotUI itemSlotUI = newItemSlotUI.GetComponent<ItemSlotUI>();
            
            if (itemSlotUI != null)
            {
                itemSlotUI.SetItemSlot(itemSlot);
                
            }
        }
    }

    public void ToggleInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
