using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject manager;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }

    private void FixedUpdate()
    {
        if(spriteRenderer.sprite != item.itemSprite)
        {
            spriteRenderer.sprite = item.itemSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add the item to the player's inventory
            InventoryManager inventoryManager = manager.transform.GetChild(4).GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                inventoryManager.AddItem(item);
            }

            // Destroy the item in the scene
            Destroy(gameObject);
        }
    }
}
