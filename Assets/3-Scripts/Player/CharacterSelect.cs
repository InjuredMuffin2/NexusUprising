using NexusUprising.Functions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;

    public CharacterClass selectedClass;
    public CharacterClass currentClass;

    public GameObject manager;
    public PlayerHealth playerHealth;
    public GameManager gameManager;

    public bool aristocratUnlocked;
    public bool mechanistUnlocked;
    public bool nexuswalkerUnlocked;
    public bool operatorUnlocked;

    public enum CharacterClass
    {
        Aristocrat = 1,
        Mechanist = 2,
        Nexuswalker = 3,
        Operator = 4,
    }

    public GameObject aristocratCharacter;
    public GameObject mechanistCharacter;
    public GameObject nexuswalkerCharacter;
    public GameObject operatorCharacter;

    public GameObject playerGO;
    public Vector2 playerPosition;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetVariablesOnStart();
    }

    private void Update()
    {
        playerGO = Common.FindPlayer(playerGO);
        KeepPlayerPosition();
        CharacterDeathHandler();

        // Swap characters if selectedClass is different from currentClass
        if (selectedClass != currentClass)
            CharacterSwapSwitch();

        // Spawn the next character if playerGO is null
        if (playerGO == null)
            SpawnNextCharacter();

        CharacterSwapInputs();
    }

    // Initialize variables at the start of the game
    private void SetVariablesOnStart()
    {
        selectedClass = CharacterClass.Aristocrat;
        currentClass = CharacterClass.Aristocrat;
        manager = GameObject.FindWithTag("Manager");
        playerHealth = manager.GetComponentInChildren<PlayerHealth>();
        gameManager = manager.GetComponentInChildren<GameManager>();
    }

    // Keep track of the player's position
    private void KeepPlayerPosition()
    {
        if (playerGO != null)
        {
            PlayerPrefs.SetFloat("playerX", playerGO.transform.position.x);
            PlayerPrefs.SetFloat("playerY", playerGO.transform.position.y);
            playerPosition = new Vector2(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"));
        }
        else
        {
            GameObject camera = GameObject.FindWithTag("MainCamera");
            playerPosition = camera.transform.position;
        }
    }

    // Handle character death and swap to the next character
    private void CharacterDeathHandler()
    {
        if(gameManager.gameOver != true)
        {
            if (selectedClass == CharacterClass.Aristocrat && playerHealth.aristocratHealth == 0)
            {
                aristocratUnlocked = false;
                selectedClass = CharacterClass.Mechanist;

                if (playerHealth.mechanistHealth != 0)
                    CharacterSwapSwitch();
            }
            else if (selectedClass == CharacterClass.Mechanist && playerHealth.mechanistHealth == 0)
            {
                mechanistUnlocked = false;
                selectedClass = CharacterClass.Nexuswalker;

                if (playerHealth.nexuswalkerHealth != 0)
                    CharacterSwapSwitch();
            }
            else if (selectedClass == CharacterClass.Nexuswalker && playerHealth.nexuswalkerHealth == 0)
            {
                nexuswalkerUnlocked = false;
                selectedClass = CharacterClass.Operator;

                if (playerHealth.operatorHealth != 0)
                    CharacterSwapSwitch();
            }
            else if (selectedClass == CharacterClass.Operator && playerHealth.operatorHealth == 0)
            {
                operatorUnlocked = false;
                selectedClass = CharacterClass.Aristocrat;

                if (playerHealth.aristocratHealth != 0)
                    CharacterSwapSwitch();
            }
        }
        else
        {
            playerGO = GameObject.FindWithTag("Player");
            Destroy(playerGO);
        }
    }

    // Swap the character based on the selected class
    private void CharacterSwapSwitch()
    {
        switch (selectedClass)
        {
            case CharacterClass.Aristocrat:
                //Spawn Aristocrat
                Destroy(GameObject.FindWithTag("Player"));
                currentClass = selectedClass;
                Instantiate(aristocratCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
                break;

            case CharacterClass.Mechanist:
                //Spawn Mechanist
                Destroy(GameObject.FindWithTag("Player"));
                currentClass = selectedClass;
                Instantiate(mechanistCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
                break;

            case CharacterClass.Nexuswalker:
                //Spawn Nexuswalker
                Destroy(GameObject.FindWithTag("Player"));
                currentClass = selectedClass;
                Instantiate(nexuswalkerCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
                break;

            case CharacterClass.Operator:
                //Spawn Operator
                Destroy(GameObject.FindWithTag("Player"));
                currentClass = selectedClass;
                Instantiate(operatorCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
                break;
        }
    }

    // Listen for character swap inputs
    private void CharacterSwapInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && aristocratUnlocked == true && playerHealth.aristocratHealth > 0)
            selectedClass = CharacterClass.Aristocrat;
        
        else if (Input.GetKeyDown(KeyCode.Alpha2) && mechanistUnlocked == true && playerHealth.mechanistHealth > 0)
            selectedClass = CharacterClass.Mechanist;
        
        else if (Input.GetKeyDown(KeyCode.Alpha3) && nexuswalkerUnlocked == true && playerHealth.nexuswalkerHealth > 0)
            selectedClass = CharacterClass.Nexuswalker;
        
        else if (Input.GetKeyDown(KeyCode.Alpha4) && operatorUnlocked == true && playerHealth.operatorHealth > 0)
            selectedClass = CharacterClass.Operator;
    }

    // Spawn the next character if the current one is dead
    private void SpawnNextCharacter()
    {
        if(aristocratUnlocked == true && playerHealth.aristocratHealth != 0)
            Instantiate(aristocratCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
        
        else if(mechanistUnlocked == true && playerHealth.mechanistHealth != 0)
            Instantiate(mechanistCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
        
        else if(nexuswalkerUnlocked == true && playerHealth.nexuswalkerHealth != 0)
            Instantiate(nexuswalkerCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
        
        else if(operatorUnlocked == true && playerHealth.operatorHealth != 0)
            Instantiate(operatorCharacter, new Vector3(playerPosition.x, playerPosition.y), Quaternion.identity);
    }
}
