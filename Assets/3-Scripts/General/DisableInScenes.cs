using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableInScenes : MonoBehaviour
{
    [System.Serializable]
    public class SceneObject
    {
        public GameObject gameObject;
        public List<int> disableInScenes = new List<int>();
    }

    public List<SceneObject> sceneObjects = new List<SceneObject>();

    // Detect when the scene changes, and run some code
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    // Detect when the scene changes, and run some code
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    // Activate and Deactivate each gameObject based on what it is set to in the inspector,
    // Each Objects that needs to be enabled/disabled in specific scenes has its own list
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        foreach (SceneObject sceneObject in sceneObjects)
        {
            if (sceneObject.gameObject != null)
            {
                if (sceneObject.disableInScenes.Contains(scene.buildIndex))
                {
                    sceneObject.gameObject.SetActive(false);
                }
                else
                {
                    sceneObject.gameObject.SetActive(true);
                }
            }
        }
    }
}
