using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    public ItemSlot publicItemSlot;
    public Image itemIcon;
    public TextMeshProUGUI itemStackSize;

    public Button itemSlotButton;

    public GameObject itemSection;
    public GameObject equipmentSection;

    public Inventory inventory;
    public Equipment equipment;

    public void Start()
    {
        itemSection = GameObject.FindWithTag("DontDestroy").transform.GetChild(1).GetChild(1).GetChild(3).gameObject;
        equipmentSection = GameObject.FindWithTag("DontDestroy").transform.GetChild(1).GetChild(1).GetChild(4).gameObject;
        inventory = GameObject.FindWithTag("Manager").transform.GetChild(4).GetComponent<Inventory>();
        equipment = GameObject.FindWithTag("Manager").transform.GetChild(8).GetComponent<Equipment>();
    }

    public void AddListener()
    {
        itemSlotButton.onClick.AddListener(OnItemSlotClicked);
    }

    public void RemoveListener()
    {
        itemSlotButton.onClick.RemoveListener(OnItemSlotClicked);
    }
    public void OnItemSlotClicked()
    {
        // set the clicked item to the equipment slot it fits into
    }

    public void SetItemSlot(ItemSlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            AddListener();
            publicItemSlot = itemSlot;

            if (!itemSlot.item.isStackable)
            {
                itemStackSize.enabled = false;
            }
            else
            {
                itemStackSize.enabled = true;
            }

            itemIcon.sprite = itemSlot.item.itemSprite;
            itemIcon.enabled = true;
            itemStackSize.text = itemSlot.stackSize.ToString();
        }
        else
        {
            RemoveListener();
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemStackSize.text = "";
        }
    }
}
