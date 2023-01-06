using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    private GameObject explosion = null;

    void Awake()
    {
        explosion = GameObject.Find("CoolExplosion");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.gameObject.SetActive(false); // hides player
            GameObject instance = Instantiate(explosion, other.transform.position, Quaternion.identity); // instantiate particle system
            instance.GetComponent<ExplosionDestroyRestart>().isNewInstance = true;
        }
    }

    /* Alternative way of collision detection
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")) {
            Debug.Log("Collided with player");
            collision.gameObject.SetActive(false);

            GameObject explosion = Instantiate(explosionE, collision.gameObject.transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            var main = explosion.GetComponent<ParticleSystem>().main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }
    }
    */
}
