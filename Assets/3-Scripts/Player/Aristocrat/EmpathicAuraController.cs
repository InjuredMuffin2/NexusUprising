using UnityEngine;

public class EmpathicAuraController : MonoBehaviour
{
    public AristocratPassiveAbility passiveAbility;
    public LayerMask allyLayerMask;
    public LayerMask enemyLayerMask;

    private void OnEnable()
    {
        if (passiveAbility != null)
        {
            passiveAbility.Activate(gameObject);
        }
    }

    private void Update()
    {
        // ApplyBuffToAllies();
        ApplyDebuffToEnemies();
    }

    private void ApplyBuffToAllies()
    {
        // Collider[] allies = Physics.OverlapSphere(transform.position, passiveAbility.allyBuffRadius, allyLayerMask);
        /*
        foreach (Collider ally in allies)
        {
            HealthSystem allyStats = ally.GetComponent<HealthSystem>();
            if (allyStats != null)
            {
                allyStats.ApplyMoveSpeedMultiplier(passiveAbility.allyMoveSpeedMultiplier);
                allyStats.ApplyDamageMultiplier(passiveAbility.allyDamageMultiplier);
            }
        }
        */
    }

    private void ApplyDebuffToEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, passiveAbility.enemyDebuffRadius, enemyLayerMask);

        if (enemies.Length > 0)
        {
            Debug.Log($"Enemies found: {enemies.Length}");
        }
        else
        {
            Debug.Log("No enemies found.");
        }

        foreach (Collider2D enemy in enemies)
        {
            Enemy enemyStats = enemy.GetComponentInParent<Enemy>();
            EnemyDamageTrigger enemyAttack = enemy.GetComponentInParent<EnemyDamageTrigger>();

            if (enemyStats != null && enemyAttack != null)
            {
                enemyStats.ApplyMoveSpeedMultiplier(passiveAbility.enemyMoveSpeedMultiplier);
                enemyAttack.ApplyDamageMultiplier(passiveAbility.enemyDamageMultiplier);
                Debug.Log($"Debuff applied to enemy: {enemy.name}");
            }
            else
            {
                Debug.Log($"Enemy components not found on enemy: {enemy.name}");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (passiveAbility != null)
        {
            // Draw the enemy debuff radius circle
            Gizmos.color = new Color(1, 0, 0, 0.5f); // Red color with 50% transparency
            Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0), passiveAbility.enemyDebuffRadius);
        }
    }
}

//Describing the Enemy GameObject Hierarchy as pseudoCode

/*
Enemy (Transform)
{
    Enemy (Transform, SpriteRenderer, RigidBody2D, Enemy, BoxCollider2D(isTrigger = false), HealthSystem)
    {
        Trigger (Transform, BoxCollider2D(isTrigger = true))
        {

        }
    }

    PatrolPointContainer (Transform)
    {
        Point1 (Transform, BoxCollider2D(isTrigger = true))
        {

        }
        Point2 (Transform, BoxCollider2D(isTrigger = true))
        {

        }
    }
}
*/