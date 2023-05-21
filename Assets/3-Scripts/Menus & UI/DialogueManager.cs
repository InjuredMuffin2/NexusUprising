using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI exitText;

    public GameObject dialogueUI;

    public float typingSpeed = 0.02f;

    private Queue<string> sentences;

    public KeyCode continueKey = KeyCode.Space;
    public KeyCode exitKey = KeyCode.Escape;

    public static bool dialogueInProgress = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetDialogueReferences();
        sentences = new Queue<string>();
    }

    private void FixedUpdate()
    {
        SetDialogueReferences();
    }

    private void Update()
    {
        if (dialogueInProgress)
        {
            if (Input.GetKeyDown(continueKey))
            {
                DisplayNextSentence();
            }
            else if (Input.GetKeyDown(exitKey))
            {
                EndDialogue();
            }
        }
    }

    public void StartDialogueSO(Dialogue dialogue)
    {
        dialogueInProgress = true;
        continueText.gameObject.SetActive(true);
        exitText.gameObject.SetActive(true);
        StartDialogue(dialogue.sentences);
    }

    public void StartDialogue(string[] dialogue)
    {
        dialogueUI.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogueInProgress = false;
    }

    private void SetDialogueReferences()
    {
        GameObject UI_GO = GameObject.FindWithTag("UI");
        if(UI_GO != null)
        {
            Transform dialoguePanelT = UI_GO.transform.GetChild(4);
            dialogueUI = dialoguePanelT.gameObject;
            dialogueText = dialogueUI.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            continueText = dialogueUI.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
            exitText = dialogueUI.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        }
    }
}
