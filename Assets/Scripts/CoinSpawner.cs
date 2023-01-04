using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coin;

    [Range(0.1f, 100)]
    public float rate;

    int xMin = -150;
    int yMin = -150;
    int zMin = 50;
    int xMax = 150;
    int yMax = 150;
    int zMax = 350;

    void Start() {
        InvokeRepeating("SpawnCoin", 0, rate);
    }

    void SpawnCoin() {
        Instantiate(coin, transform.position, transform.rotation);

        transform.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
    }

}
