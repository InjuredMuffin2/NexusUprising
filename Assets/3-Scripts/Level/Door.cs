using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OpeningType
{
    Instant = 0,
    Up = 1,
    Down = 2,
    Animation = 3,
}
public class Door : MonoBehaviour
{
    public Switch connectedSwitch;
    public Animator doorAnimator;
    public CameraFollowTarget cameraFollowTarget;

    public OpeningType openingType;

    public float openDistance;
    public float openingSpeed;
    private float originalY;

    public bool forceCameraLook;

    private void Awake()
    {
        SetVariablesOnAwake();
    }

    private void Start()
    {
        SetVariablesOnStart();
    }
    private void FixedUpdate()
    {
        OpeningMechanism();
    }



    private void SetVariablesOnAwake()
    {
        if (openingSpeed == 0)
        {
            openingSpeed = 1;
        }

        originalY = transform.position.y;
    }
    private void SetVariablesOnStart()
    {
        GameObject cameraGO = GameObject.FindWithTag("MainCamera");
        cameraFollowTarget = cameraGO.GetComponent<CameraFollowTarget>();
    }
    private void OpeningMechanism()
    {
        switch (openingType)
        {
            // as the name implies this switch will instantly open the door
            case OpeningType.Instant:
                if (connectedSwitch.switchStatus == SwitchStatus.ON)
                {
                    gameObject.SetActive(false);
                }
                break;

            // opens the door by moving it upwards
            case OpeningType.Up:
                if (connectedSwitch.switchStatus == SwitchStatus.ON && transform.position.y < originalY + openDistance)
                {
                    // if set to allow it, also force the camera to look at the door while its opening
                    if (forceCameraLook == true)
                    {
                        cameraFollowTarget.target = gameObject;
                    }
                    // move the door
                    transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * openingSpeed);
                }
                // once movement is finished disable door script for performance and remove target on cameraFollowTarget script
                else if (transform.position.y >= originalY + openDistance)
                {
                    Door door = gameObject.GetComponent<Door>();
                    door.enabled = false;
                    cameraFollowTarget.target = null;
                }
                break;

            // opens the door by moving it downwards
            case OpeningType.Down:
                if (connectedSwitch.switchStatus == SwitchStatus.ON && transform.position.y > originalY - openDistance)
                {
                    // if set to allow it, also force the camera to look at the door while its opening
                    if (forceCameraLook == true)
                    {
                        cameraFollowTarget.target = gameObject;
                    }
                    // move the door
                    transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * openingSpeed);
                }
                // once movement is finished disable door script for performance and remove target on cameraFollowTarget script
                else if (transform.position.y <= originalY - openDistance)
                {
                    Door door = gameObject.GetComponent<Door>();
                    door.enabled = false;
                    cameraFollowTarget.target = null;
                }
                break;

            case OpeningType.Animation:
                // code for opening a door with a set animation goes here
                break;
        }
    }
}
