using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public Vector2 speed = new Vector2(0f, 0f); // the movement speed of the cloud

    void Update()
    {
        // move the cloud in the x direction at the specified speed
        transform.Translate(speed[0] * Time.deltaTime, 0, speed[1] * Time.deltaTime);

        // destroy the cloud if it goes off screen
        if (transform.position.x > 1000 || transform.position.x < 0 || transform.position.y > 1000 || transform.position.y < 0)
        {
            Destroy(gameObject);
            CloudController cc = FindObjectOfType<CloudController>();
            cc.SpawnCloud();

        }
    }
}




