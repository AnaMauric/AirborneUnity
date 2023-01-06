using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionDestroyRestart : MonoBehaviour
{
    public bool isNewInstance = false;

    private ParticleSystem ps;

    private AudioSource asrc;

    void Start() {
        //ps = GetComponent<ParticleSystem>();
        if (isNewInstance == false) return;
        asrc = GetComponent<AudioSource>();
        asrc.Play();
        Invoke("goToMainMenu", 2f);
        Destroy(gameObject, 2f);

    }

    void Update() {
        //if(!ps.IsAlive()) {
    
        //}
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
