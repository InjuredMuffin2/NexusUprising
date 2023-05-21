using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NexusUprising.Enumerators;

public class ProjectileData : MonoBehaviour
{
    public ObjectType ownership;

    public int projectileDamage;

    private void Awake()
    {
        if (ownership == ObjectType.Player)
        {
            projectileDamage = PlayerAttack.instance.playerDamage;
        }
    }
}
