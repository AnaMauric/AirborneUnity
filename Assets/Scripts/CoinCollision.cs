using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {
    public GameObject coinCollisionParticleSystem = null;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Destroy(gameObject);
            FuelManager.fuel += 1.0f;
            Instantiate(coinCollisionParticleSystem, transform.position, Quaternion.identity); // instantiate particle system
        }
    }

}