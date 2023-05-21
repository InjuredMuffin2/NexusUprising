using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NexusUprising.Enumerators;

public class HealthSystem : MonoBehaviour
{
    // This script is for both enemy and ally health
    public GameObject healthGameObject;
    public int currentHealth;
    public int maxHealth;
    public float damageMultiplier = 1f; // New variable to handle damage multipliers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            int damage = 1;

            if (collision.GetComponent<ProjectileData>())
            {
                damage = collision.gameObject.GetComponent<ProjectileData>().projectileDamage;
            }

            // Apply the damage with the current damage multiplier
            TakeDamage(damage);
        }
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // New method to handle taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= Mathf.RoundToInt(damage * damageMultiplier);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    // New methods to handle damage multipliers, buffs, and debuffs
    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }

    public void ResetDamageMultiplier()
    {
        damageMultiplier = 1f;
    }
}
