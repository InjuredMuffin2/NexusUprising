using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AristocratUltimateAbility", menuName = "Abilities/Aristocrat Ultimate")]
public class AristocratUltimateAbility : CharacterAbility
{
    public float currentUltimateCharge;
    public float enrageDuration = 15f;
    public float damageMultiplier = 3f;
    public float moveSpeedMultiplier = 1.6f;
    public float attackSpeedMultiplier = 1.25f;

    public override void Activate(GameObject player)
    {
        player.GetComponent<CharacterAbilities>().StartCoroutine(Reckoning(player));
    }

    private IEnumerator Reckoning(GameObject player)
    {
        // Implement logic to apply damage, move speed, and attack speed buffs
        // You can use separate components or methods to handle these effects.

        yield return new WaitForSeconds(enrageDuration);

        // Revert the damage, move speed, and attack speed buffs
    }
}
