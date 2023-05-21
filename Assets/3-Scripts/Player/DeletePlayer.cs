using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NexusUprising.Enumerators;

public class DeletePlayer : MonoBehaviour
{
    public GameObject manager;
    public CharacterSelect characterSelect;
    public CharacterSelect.CharacterClass characterClass;
    private void Update()
    {
        manager = GameObject.FindWithTag("Manager");

        if(manager != null && characterSelect == null)
        {
            manager.GetComponentInChildren<CharacterSelect>();
        }
        if (characterClass != CharacterSelect.instance.currentClass)
        {
            Destroy(gameObject);
        }
    }
}
