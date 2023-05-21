using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    [SerializeField]
    private int currentDamage = 1, baseDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.DealDamageToPlayer(currentDamage);
        }
    }

    private void Start()
    {
        currentDamage = baseDamage;
    }

    public void ApplyDamageMultiplier(float multiplier)
    {
        currentDamage = (int)(baseDamage * multiplier);
    }
}
