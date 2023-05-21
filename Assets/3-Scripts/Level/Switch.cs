using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwitchType
{
    Automatic = 0,
    Manual = 1
}

public enum SwitchStatus
{
    OFF = 0,
    ON = 1,
}

public class Switch : MonoBehaviour
{
    public SwitchType switchType;
    public SwitchStatus switchStatus;
    public bool singleUse;

    private SpriteRenderer switchSpriteRenderer;
    private Capabilities playerCapabilities;
    private Light switchLight;

    private List<Capabilities> capabilitiesList;

    public Color onColor;
    public Color offColor;

    private void Awake()
    {
        SetVariablesOnAwake();
    }

    public void FixedUpdate()
    {
        // Update light color based on sprite renderer color
        switchLight.color = switchSpriteRenderer.color;

        switch (switchType)
        {
            case SwitchType.Automatic:
                if (capabilitiesList.Count != 0)
                {
                    switchStatus = SwitchStatus.ON;

                    if (singleUse)
                    {
                        switchSpriteRenderer.color = onColor;
                        switchLight.color = switchSpriteRenderer.color;
                        GetComponent<Switch>().enabled = false;
                    }
                }
                else
                {
                    if (!singleUse)
                        switchStatus = SwitchStatus.OFF;
                }
                break;

            case SwitchType.Manual:
                //Nothing
                break;
        }
    }

    private void Update()
    {
        // Update sprite renderer color based on switch status
        switch (switchType)
        {
            case SwitchType.Automatic:
            case SwitchType.Manual:
                switchSpriteRenderer.color = switchStatus == SwitchStatus.ON ? onColor : offColor;
                break;
        }

        // Toggle switch status for manual switches when Mouse1 is pressed and playerCapabilities is not null
        if (switchType == SwitchType.Manual && Input.GetKeyDown(KeyCode.E) && playerCapabilities != null && playerCapabilities.canUseSwitches)
        {
            switchStatus = switchStatus == SwitchStatus.OFF ? SwitchStatus.ON : SwitchStatus.OFF;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Capabilities capability = collision.GetComponent<Capabilities>();
        if (capability != null && capability.canUseSwitches)
        {
            capabilitiesList.Add(capability);
            if (collision.CompareTag("Player"))
            {
                playerCapabilities = capability;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Capabilities capability = collision.GetComponent<Capabilities>();
        if (capability != null)
        {
            capabilitiesList.Remove(capability);
            if (collision.CompareTag("Player"))
            {
                playerCapabilities = null;
            }
        }
    }

    private void SetVariablesOnAwake()
    {
        capabilitiesList = new List<Capabilities>();
        switchSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Transform childGO = transform.GetChild(1);
        switchLight = childGO.GetComponent<Light>();

        if (offColor == new Color32(0, 0, 0, 0))
        {
            offColor = Color.red;
        }
        if (onColor == new Color32(0, 0, 0, 0))
        {
            onColor = Color.green;
        }
    }
}
