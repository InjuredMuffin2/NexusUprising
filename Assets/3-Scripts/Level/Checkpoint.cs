using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider that entered the trigger is the player
        if (collision.CompareTag("Player"))
        {
            // Set the checkpoint position in the GameManager
            GameManager.instance.SetCheckpoint(transform.position);
        }
    }
}
