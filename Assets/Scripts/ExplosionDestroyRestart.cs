using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionDestroyRestart : MonoBehaviour
{
    public bool isNewInstance = false;

    private ParticleSystem ps;

    private AudioSource aSrc;


    void Start() {
        //ps = GetComponent<ParticleSystem>();
        if (isNewInstance == false) return;
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        aSrc = GetComponent<AudioSource>();
        aSrc.Play();
        Invoke("GoToMainMenu", 2f);
        //Destroy(gameObject, 1.7f);
    }

    void Update() {
        //if(!ps.IsAlive()) {

        //}
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
