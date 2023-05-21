using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public Transform targetDoor;

    private bool playerInRange;
    public bool useTargetZPosition;
    public Vector3 offset;

    private void Update()
    {
        // Check if the player is in range and the "W" key is pressed, then teleport the player
        if (playerInRange && Input.GetKeyDown(KeyCode.W))
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the colliding object is the player, set playerInRange to true
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the player leaves the trigger area, set playerInRange to false
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void TeleportPlayer()
    {
        // Get the player GameObject and the target position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 targetPosition = targetDoor.position;

        // If useTargetZPosition is false, set target position Z to 0
        if (!useTargetZPosition)
        {
            targetPosition.z = 0;
        }

        // Set the player's position to the target position
        player.transform.position = targetPosition + offset;
    }
}
