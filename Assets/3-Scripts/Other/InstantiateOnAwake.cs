using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnAwake : MonoBehaviour
{
    public GameObject createOnAwake;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if there's no GameObject with the "DontDestroy" name
        if (GameObject.FindWithTag("DontDestroy") == null)
        {
            // Instantiate the specified GameObject
            Instantiate(createOnAwake);
        }
    }
}
