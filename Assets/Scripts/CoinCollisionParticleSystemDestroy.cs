using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionParticleSystemDestroy : MonoBehaviour {
    private ParticleSystem ps;

    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        if(!ps.IsAlive()) {
            Destroy(gameObject);
        }
    }
}
