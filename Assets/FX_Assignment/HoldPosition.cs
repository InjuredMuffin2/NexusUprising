using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPosition : MonoBehaviour
{
    [Header("Object-Based Positioning")]
    public bool useObject;
    [Space]
    public Transform followPoint;
    public Vector3 offset;
    private void FixedUpdate()
    {
        gameObject.transform.position = followPoint.position + offset;
    }
}
