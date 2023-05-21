using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonControl : MonoBehaviour
{
    // Create a serializable class to hold button GameObjects and the value at which they should be enabled
    [System.Serializable]
    public class ButtonControl
    {
        public GameObject buttonGameObject;
        public int enableAtValue;
    }

    // Create a list to hold ButtonControl objects
    public List<ButtonControl> ButtonList = new List<ButtonControl>();

    // Run the EnableButtons function on Start
    void Start()
    {
        EnableButtons();
    }

    // Function to enable buttons based on the number of levels completed
    private void EnableButtons()
    {
        // Iterate through the ButtonList
        foreach (ButtonControl button in ButtonList)
        {
            // Check if the button should be enabled
            if (GameManager.instance.levelsCompleted >= button.enableAtValue)
            {
                // Enable the button
                button.buttonGameObject.SetActive(true);

                // If the most recently completed level unlcoked the button, change the color to make it stand out more
                if (GameManager.instance.levelsCompleted == button.enableAtValue)
                {
                    var colors = button.buttonGameObject.GetComponent<Button>().colors;

                    // Find the button color comonent
                    if (colors != null)
                    {
                        // Set the normal color to a custom color
                        colors.normalColor = new Color32(255, 25, 75, 255);
                        // Apply the modified colors to the button
                        button.buttonGameObject.GetComponent<Button>().colors = colors;
                    }
                    else
                    {
                        // If the button doesn't have a colors component, change the Image color instead
                        Image sprite = button.buttonGameObject.GetComponent<Image>();
                        sprite.color = Color.red;
                    }
                }
            }
            else
            {
                // Disable the button if it should not be enabled
                button.buttonGameObject.SetActive(false);
            }
        }
    }
}