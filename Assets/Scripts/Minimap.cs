using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform plane;

    void LateUpdate()
    {
        Vector3 newPosition = plane.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, plane.eulerAngles.y, 0f);
    }
}
