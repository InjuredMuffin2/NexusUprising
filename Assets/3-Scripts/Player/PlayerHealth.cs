using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NexusUprising;
using NexusUprising.Functions;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public GameObject playerGO;
    public CharacterSelect characterSelect;
    public GameManager gameManager;

    public int aristocratHealth;
    public int mechanistHealth;
    public int nexuswalkerHealth;
    public int operatorHealth;

    private int aristocratStartingHealth;
    private int mechanistStartingHealth;
    private int nexuswalkerStartingHealth;
    private int operatorStartingHealth;

    public int aristocratMaxHealth;
    public int mechanistMaxHealth;
    public int nexuswalkerMaxHealth;
    public int operatorMaxHealth;

    private void Awake()
    {
        instance = this;
        SetVariablesOnAwake();
    }
    private void Start()
    {
        SetVariablesOnStart();
    }
    private void FixedUpdate()
    {
        playerGO = Common.FindPlayer(playerGO);
        MaxHealthCalculation();
        CheckForGameOver();
    }

    // Deal damage to the player based on the current character class
    public void DealDamageToPlayer(int damage)
    {
        switch (characterSelect.currentClass)
        {
            case CharacterSelect.CharacterClass.Aristocrat:
                aristocratHealth -= damage;
                if (aristocratHealth < 0)
                {
                    aristocratHealth = 0;
                }
                break;

            case CharacterSelect.CharacterClass.Mechanist:
                mechanistHealth -= damage;
                if (mechanistHealth < 0)
                {
                    mechanistHealth = 0;
                }
                break;

            case CharacterSelect.CharacterClass.Nexuswalker:
                nexuswalkerHealth -= damage;
                if (nexuswalkerHealth < 0)
                {
                    nexuswalkerHealth = 0;
                }
                break;

            case CharacterSelect.CharacterClass.Operator:
                operatorHealth -= damage;
                if (operatorHealth < 0)
                {
                    operatorHealth = 0;
                }
                break;
        }
    }

    private void SetVariablesOnAwake()
    {
        //nothing at the moment
    }

    // Set initial health values and references on start
    private void SetVariablesOnStart()
    {
        playerGO = GameObject.FindWithTag("Player");
        GameObject managerGO = GameObject.FindWithTag("Manager");
        characterSelect = managerGO.GetComponentInChildren<CharacterSelect>();
        gameManager = managerGO.GetComponentInChildren<GameManager>();

        // Set starting health for unlocked character classes
        if (characterSelect.aristocratUnlocked)
        {
            if (aristocratHealth == 0)
            {
                aristocratHealth = 5;
            }
            aristocratStartingHealth = aristocratHealth;
        }

        if (characterSelect.mechanistUnlocked)
        {
            if (mechanistHealth == 0)
            {
                mechanistHealth = 3;
            }
            mechanistStartingHealth = mechanistHealth;
        }

        if (characterSelect.nexuswalkerUnlocked)
        {
            if (nexuswalkerHealth == 0)
            {
                nexuswalkerHealth = 6;
            }
            nexuswalkerStartingHealth = nexuswalkerHealth;
        }

        if (characterSelect.operatorUnlocked)
        {
            if (operatorHealth == 0)
            {
                operatorHealth = 4;
            }
            operatorStartingHealth = operatorHealth;
        }

        FindPlayerWhenNull();
    }

    // Calculate max health for each character class
    public void MaxHealthCalculation()
    {
        aristocratMaxHealth = aristocratStartingHealth;
        mechanistMaxHealth = mechanistStartingHealth;
        nexuswalkerMaxHealth = nexuswalkerStartingHealth;
        operatorMaxHealth = operatorStartingHealth;

        // Ensure current health does not exceed max health for each character class
        if (aristocratHealth > aristocratMaxHealth)
        {
            aristocratHealth = aristocratMaxHealth;
        }
        if (mechanistHealth > mechanistMaxHealth)
        {
            mechanistHealth = mechanistMaxHealth;
        }
        if (nexuswalkerHealth > nexuswalkerMaxHealth)
        {
            nexuswalkerHealth = nexuswalkerMaxHealth;
        }
        if (operatorHealth > operatorMaxHealth)
        {
            operatorHealth = operatorMaxHealth;
        }
    }

    // Find player game object when it is not assigned
    private void FindPlayerWhenNull()
    {
        if (playerGO == null)
        {
            playerGO = GameObject.FindWithTag("Player");
        }
    }

    // Check for game over condition when all character class health is zero
    private void CheckForGameOver()
    {
        if (aristocratHealth + mechanistHealth + nexuswalkerHealth + operatorHealth == 0)
        {
            gameManager.gameOver = true;
        }
    }
}
