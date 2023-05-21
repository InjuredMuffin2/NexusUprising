using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            Move(new Vector3(0, -1, 5));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, 270, 0);
            Move(new Vector3(-5, -1, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            Move(new Vector3(0, -1, -5));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            Move(new Vector3(5, -1, 0));
        }
        else
        {
            Move(new Vector3(0, -1, 0));
        }
    }

    private void Move(Vector3 force)
    {
        gameObject.GetComponent<Rigidbody>().velocity = force;
    }
}
