using NexusUprising;
using NexusUprising.Functions;
using UnityEngine;

public class SwitchColourChanger : MonoBehaviour
{
    public Material circleMaterial;
    public Color activeColor;
    public Color inactiveColor;
    public Switch connectedSwitch;

    private void FixedUpdate()
    {
        if  (connectedSwitch.switchStatus == SwitchStatus.ON)
        {
            circleMaterial.SetColor("_Color", activeColor);
        }
        else
        {
            circleMaterial.SetColor("_Color", inactiveColor);
        }
    }
}
