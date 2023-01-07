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
        Invoke("goToMainMenu", 2f);
        Destroy(gameObject, aSrc.clip.length);

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
