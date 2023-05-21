using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchConnection : MonoBehaviour
{
    public Switch connectedSwitch;
    public GameObject connectedGameObject;

    public void FixedUpdate()
    {
        if(connectedSwitch.switchStatus == SwitchStatus.OFF)
            connectedGameObject.SetActive(false);
        else
            connectedGameObject.SetActive(true);
    }
}
