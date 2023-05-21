using NexusUprising.Functions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject target;

    public Vector2 scrollDelta;

    public float cameraDistance;
    public float xModifier, yModifier;
    public float minDistance, maxDistance;

    public void Awake()
    {
        SetVariablesOnAwake();
    }

    void FixedUpdate()
    {
        target = Common.FindPlayer(target);
        SetTargetDependantLimits();
    }

    public void Update()
    {
        WatchTarget();
        CameraScrolling();
        LockCameraDistance();
    }

    private void SetVariablesOnAwake()
    {
        xModifier = 0;
        yModifier = 2;
        minDistance = 7;
        maxDistance = 20;
        cameraDistance = -20;
    }

    // Set camera limits based on the target type
    private void SetTargetDependantLimits()
    {
        if (target != null && target.CompareTag("Player"))
        {
            xModifier = 0;
            yModifier = 2;
            minDistance = 7;
            maxDistance = 20;
        }
        else
        {
            xModifier = 0;
            yModifier = -2;
            minDistance = 10;
            maxDistance = 10;
        }
    }

    // Set the camera position to follow the target
    private void WatchTarget()
    {
        if (target != null)
        {
            playerCamera.transform.position = new Vector3(target.transform.position.x + xModifier, target.transform.position.y + yModifier, cameraDistance);
        }
    }

    // Lock the camera distance within a defined range
    private void LockCameraDistance()
    {
        if (target != null)
        {
            if (cameraDistance > target.transform.position.z - minDistance)
            {
                cameraDistance = target.transform.position.z - minDistance;
            }
            else if (cameraDistance < target.transform.position.z - maxDistance)
            {
                cameraDistance = target.transform.position.z - maxDistance;
            }
        }
    }

    // Handle camera zoom using the mouse scroll wheel
    private void CameraScrolling()
    {
        scrollDelta = Input.mouseScrollDelta;

        if (scrollDelta.y < 0)
        {
            cameraDistance = cameraDistance + -1;
        }
        else if (scrollDelta.y > 0)
        {
            cameraDistance = cameraDistance + 1;
        }
    }
}
