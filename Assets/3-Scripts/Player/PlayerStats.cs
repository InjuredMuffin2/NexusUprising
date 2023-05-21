using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    // Add other stats as needed, e.g., speed, mana, etc.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add methods for modifying stats, taking damage, healing, etc.
    public void TakeDamage(int damage)
    {
        int effectiveDamage = Mathf.Max(damage - defense, 0);
        health -= effectiveDamage;

        if (health <= 0)
        {
            // Handle player death
        }
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }
}
