using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver;

    public int levelsCompleted = -1;

    public Vector3 checkpoint;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpoint = position;
    }

    public Vector3 GetPosition()
    {
        return checkpoint;
    }
}
