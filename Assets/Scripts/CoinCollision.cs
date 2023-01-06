using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {
    public GameObject coinCollisionParticleSystem = null;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Destroy(gameObject);
            CoinsManager.pickedUp();

            Instantiate(coinCollisionParticleSystem, transform.position, Quaternion.identity); // instantiate particle system
        }
    }

}