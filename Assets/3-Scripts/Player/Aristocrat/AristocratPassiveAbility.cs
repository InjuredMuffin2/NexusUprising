using UnityEngine;

[CreateAssetMenu(fileName = "VeridiaPassiveAbility", menuName = "Abilities/Veridia Passive")]
public class AristocratPassiveAbility : CharacterAbility
{
    public float allyBuffRadius = 12f;
    public float allyMoveSpeedMultiplier = 1.2f;
    public float allyDamageMultiplier = 1.2f;

    public float enemyDebuffRadius = 14f;
    public float enemyMoveSpeedMultiplier = 0.2f;
    public float enemyDamageMultiplier = 0.9f;

    public override void Activate(GameObject player)
    {
        // Since this is a passive ability, the logic will be implemented
        // in another script that constantly checks for allies and enemies
        // within the radius of the character
    }
}
