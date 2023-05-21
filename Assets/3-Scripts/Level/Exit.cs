using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string nextScene;
    public int levelsCompleted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (levelsCompleted > GameManager.instance.levelsCompleted)
            {
                GameManager.instance.levelsCompleted = levelsCompleted;
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}
