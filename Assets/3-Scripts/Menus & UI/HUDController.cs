using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    public CharacterSelect characterSelect;
    public PlayerHealth playerHealth;

    public Slider healthBarSlider;
    public Image healthBarImage;

    public Color aristocratHealthBar;
    public Color mechanistHealthBar;
    public Color nexuswalkerHealthBar;
    public Color operatorHealthBar;

    public GameObject HUD;
    public GameObject inventory;
    public GameObject gearInventory;
    public GameObject equipmentInventory;
    public GameObject materialInventory;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if(GameObject.FindWithTag("Manager") != null)
        characterSelect = GameObject.FindWithTag("Manager").GetComponentInChildren<CharacterSelect>();
        if(GameObject.FindWithTag("Manager") != null)
        playerHealth = GameObject.FindWithTag("Manager").GetComponentInChildren<PlayerHealth>();
    }
    private void FixedUpdate()
    {
        HealthBarController();
    }
    private void Update()
    {
        InventoryControlWithButtons();
    }



    private void HealthBarController()
    {
        if(characterSelect == null)
        characterSelect = GameObject.FindWithTag("Manager").GetComponentInChildren<CharacterSelect>();

        if(playerHealth == null)
        playerHealth = GameObject.FindWithTag("Manager").GetComponentInChildren<PlayerHealth>();

        if (characterSelect != null && characterSelect.selectedClass == CharacterSelect.CharacterClass.Aristocrat)
        {
            healthBarImage.color = aristocratHealthBar;

            if (playerHealth.aristocratHealth > 0)
                healthBarSlider.value = (float)playerHealth.aristocratHealth / playerHealth.aristocratMaxHealth;
        }
        else if (characterSelect != null && characterSelect.selectedClass == CharacterSelect.CharacterClass.Mechanist)
        {
            healthBarImage.color = mechanistHealthBar;

            if (playerHealth.mechanistHealth > 0)
                healthBarSlider.value = (float)playerHealth.mechanistHealth / playerHealth.mechanistMaxHealth;
        }
        else if (characterSelect != null && characterSelect.selectedClass == CharacterSelect.CharacterClass.Nexuswalker)
        {
            healthBarImage.color = nexuswalkerHealthBar;

            if (playerHealth.nexuswalkerHealth > 0)
                healthBarSlider.value = (float)playerHealth.nexuswalkerHealth / playerHealth.nexuswalkerMaxHealth;
        }
        else if (characterSelect != null && characterSelect.selectedClass == CharacterSelect.CharacterClass.Operator)
        {
            healthBarImage.color = operatorHealthBar;

            if (playerHealth.operatorHealth > 0)
                healthBarSlider.value = (float)playerHealth.operatorHealth / playerHealth.operatorMaxHealth;
        }
    }

    private void InventoryControlWithButtons()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && inventory.activeSelf == false)
        {
            HUD.SetActive(false);
            inventory.SetActive(true);
            InventoryUIManager UIUpdate = GameObject.FindWithTag("Manager").transform.GetChild(7).GetComponent<InventoryUIManager>();
            UIUpdate.UpdateInventoryUI();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventory.activeSelf == true)
        {
            if (gearInventory.activeSelf == true)
            {
                gearInventory.SetActive(false);
                equipmentInventory.SetActive(false);
                materialInventory.SetActive(true);
            }
            else if (materialInventory.activeSelf == true)
            {
                materialInventory.SetActive(false);
                equipmentInventory.SetActive(true);
                gearInventory.SetActive(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape) && inventory.activeSelf == true)
        {
            inventory.SetActive(false);
            HUD.SetActive(true);
        }
    }
}
