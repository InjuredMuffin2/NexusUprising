using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TutorialTriggers : MonoBehaviour
{
    public GameObject tutorialGO;
    private void Awake()
    {
        tutorialGO = gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Once the player leaves the area of the tutorial sprite, destroy it as it is no longer needed
        if(collision.CompareTag("Player"))
            GameObject.Destroy(tutorialGO);
    }
}
