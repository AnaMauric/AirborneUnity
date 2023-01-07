using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinAI : MonoBehaviour
{
    public Transform target; // Assign the target in the Inspector
    public float speed = 5f; // Speed at which the object flies towards the right
    public float rotationRate = 0.5f; // Rotation rate around the target

    void FixedUpdate()
    {
        // Look at the target
        transform.LookAt(target);

        // Move towards the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Rotate around the target
        transform.RotateAround(target.position, Vector3.up, rotationRate * Time.deltaTime);
        transform.Rotate(Vector3.right, -90f, Space.Self);
        transform.Rotate(Vector3.forward, -90f, Space.Self);

    }
}



