using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject manager;
    public PlayerHealth playerHealth;
    public CharacterSelect characterSelect;

    public int hazardDamage;

    private void Start()
    {
        SetVariablesOnStart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (playerHealth != null)
            {
                playerHealth.DealDamageToPlayer(hazardDamage);
            }
        }
    }

    private void SetVariablesOnStart()
    {
        manager = GameObject.FindWithTag("Manager");
        playerHealth = manager.GetComponentInChildren<PlayerHealth>();

        if(hazardDamage >= 0)
        {
            hazardDamage = 1;
        }
    }
}
