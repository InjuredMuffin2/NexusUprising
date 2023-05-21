using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAbility : ScriptableObject
{
    public abstract void Activate(GameObject player);
}
