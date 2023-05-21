using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.instance.LoadSceneByName("Map");
    }

    public void QuitGame()
    {
        SceneController.instance.QuitGame();
    }
}
