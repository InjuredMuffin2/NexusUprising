using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NexusUprising.Enumerators;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;
    public int playerDamage;
    public GameObject weaponSlot;


    // Add a variable to store the current weapon type
    public ItemCategory currentWeaponType = ItemCategory.Weapon_Melee;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (weaponSlot != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Call different attack methods based on the current weapon type
        switch (currentWeaponType)
        {
            case ItemCategory.Weapon_Melee:
                MeleeAttack();
                break;
            case ItemCategory.Weapon_Ranged:
                RangedAttack();
                break;
            case ItemCategory.Weapon_Magic:
                MagicAttack();
                break;
        }
    }

    private void MeleeAttack()
    {
        // Implement melee attack logic
    }

    private void RangedAttack()
    {
        // Implement ranged attack logic
    }

    private void MagicAttack()
    {
        // Implement magic attack logic
    }
}