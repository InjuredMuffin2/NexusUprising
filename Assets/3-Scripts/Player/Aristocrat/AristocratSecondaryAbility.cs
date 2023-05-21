using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AristocratSecondaryAbility", menuName = "Abilities/Aristocrat Secondary")]
public class AristocratSecondaryAbility : CharacterAbility
{
    public float invisibilityDuration = 5f;
    public float moveSpeedMultiplier = 1.4f;
    public GameObject clonePrefab;

    public override void Activate(GameObject player)
    {
        player.GetComponent<CharacterAbilities>().StartCoroutine(Invisibility(player));
    }

    private IEnumerator Invisibility(GameObject player)
    {
        // Implement logic to turn the player invisible
        // You may want to add a separate component or method to handle the invisibility effect.

        // Apply the move speed buff
        // You can use a separate component or method to handle the speed buff effect.

        // Create a clone
        GameObject clone = Instantiate(clonePrefab, player.transform.position, player.transform.rotation);

        // The clone could have its own behavior, like standing still or moving around.
        // You can add a script to the clone prefab to control its behavior.

        yield return new WaitForSeconds(invisibilityDuration);

        // Revert the invisibility effect and the move speed buff

        // Destroy the clone
        Destroy(clone);
    }
}
