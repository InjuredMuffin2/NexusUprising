using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToCheckpoint : MonoBehaviour
{
    public bool dealDamage;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the collision is the player, teleport the player to their most recent Checkpoint
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.DealDamageToPlayer(1);
            Vector3 checpointPosition = GameManager.instance.GetPosition();
            collision.transform.position = checpointPosition;

            //If the collider is set to deal damage, deal damage
            if (dealDamage)
            {
                PlayerHealth.instance.DealDamageToPlayer(damage);
            }
        }
    }
}
