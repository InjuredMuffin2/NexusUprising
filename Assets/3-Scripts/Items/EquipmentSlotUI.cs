using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    public Sprite defaultIcon;
    public Image itemIcon;
    public EquipmentSlot equipmentSlot;

    public void FixedUpdate()
    {
        if (this.enabled == true)
        {
            SetEquipmentSlot(equipmentSlot);
        }
    }

    public void SetEquipmentSlot(EquipmentSlot itemSlot)
    {
        if (itemSlot.item != null)
        {
            itemIcon.sprite = itemSlot.item.itemSprite;
        }
        else
        {
            itemIcon.sprite = defaultIcon;
        }
    }
}
