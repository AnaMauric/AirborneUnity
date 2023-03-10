using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollision : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 360f / 4f * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FuelManager.Refuel();
            gameObject.SetActive(false);
            Invoke("ShowObject", 10f);
        }


    }
    void ShowObject()
    {
        gameObject.SetActive(true);
    }
}
