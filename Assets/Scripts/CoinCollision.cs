using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour {
    public GameObject coinCollisionParticleSystem = null;
    private AudioSource aSrc = null;

    void Awake()
    {
        aSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            aSrc.Play();
            CoinsManager.pickedUp();
            GetComponent<Renderer>().enabled = false;
            Instantiate(coinCollisionParticleSystem, transform.position, Quaternion.identity); // instantiate particle system
            Destroy(gameObject, aSrc.clip.length);
        }
    }

}