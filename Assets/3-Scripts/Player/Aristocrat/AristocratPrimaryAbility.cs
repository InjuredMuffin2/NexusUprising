using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AristocratPrimaryAbility", menuName = "Abilities/Aristocrat Primary")]
public class AristocratPrimaryAbility : CharacterAbility
{
    public float radius = 10f;
    public LayerMask enemyLayerMask;
    public float damageMultiplierNotHit = 2f;
    public float damageMultiplierHit10Sec = 4f;
    public float damageMultiplierHit5Sec = 8f;

    public override void Activate(GameObject player)
    {
        List<GameObject> enemies = GetEnemiesAroundPlayer(player);

        foreach (GameObject enemy in enemies)
        {
            // Implement the logic to determine how recently the enemy hit the player, and
            // apply the appropriate damage multiplier based on the timing.

            // You will need to create a method or component to track when the player is hit by each enemy.
        }
    }

    private List<GameObject> GetEnemiesAroundPlayer(GameObject player)
    {
        Collider[] enemyColliders = Physics.OverlapSphere(player.transform.position, radius, enemyLayerMask);
        List<GameObject> enemies = new List<GameObject>();

        foreach (Collider enemyCollider in enemyColliders)
        {
            enemies.Add(enemyCollider.gameObject);
        }

        return enemies;
    }
}
