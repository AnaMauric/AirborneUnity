using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target; // The object to rotate around
    public float speed = 5.0f; // The rotation speed

    void Update()
    {
        // Rotate around the target object
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

        // Look at the target object
        transform.LookAt(target);
    }
}




