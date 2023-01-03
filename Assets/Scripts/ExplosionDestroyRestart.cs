using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionDestroyRestart : MonoBehaviour
{
    private ParticleSystem ps;

    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        if(!ps.IsAlive()) {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
