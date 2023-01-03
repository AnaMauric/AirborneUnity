using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coin;

    [Range(1, 10)]
    public float rate;

    int min = 0;
    int max = 100;

    void Start() {
        InvokeRepeating("SpawnCoin", 0, rate);
    }

    void SpawnCoin() {
        Instantiate(coin, transform.position, transform.rotation);

        transform.position = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }
}
