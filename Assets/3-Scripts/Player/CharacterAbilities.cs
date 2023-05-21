using NexusUprising.Functions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public GameObject playerGO;
    public CharacterAbility passive;
    public CharacterAbility primary;
    public CharacterAbility secondary;
    public CharacterAbility ultimate;

    private void Update()
    {
        // Find the active player character if it's not set
        playerGO = Common.FindPlayer(playerGO);


        // Check for input and activate abilities accordingly
        if (Input.GetKeyDown(KeyCode.Q) && primary != null)
        {
            primary.Activate(playerGO);
        }
        if (Input.GetKeyDown(KeyCode.C) && secondary != null)
        {
            secondary.Activate(playerGO);
        }
        if (Input.GetKeyDown(KeyCode.X) && ultimate != null)
        {
            ultimate.Activate(playerGO);
        }
    }
}