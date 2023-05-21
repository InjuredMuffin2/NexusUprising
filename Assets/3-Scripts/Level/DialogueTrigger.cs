using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public KeyCode interactKey = KeyCode.E;
    public bool requireKeyPress;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (!requireKeyPress || Input.GetKeyDown(interactKey))
            {
                DialogueManager.instance.StartDialogueSO(dialogue);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
