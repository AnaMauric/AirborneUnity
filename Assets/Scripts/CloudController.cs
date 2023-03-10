using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject cloudPrefab; // a prefab for the clouds
    public float minSpeed = -5f; // the minimum speed for clouds
    public float maxSpeed = 5f; // the maximum speed for clouds
    public int amountOfClouds = 10;
    public float minScale = 0.6f; 
    public float maxScale = 1f; 

    void Start()
    {
        // spawn the first cloud immediately
        for (int i = 0; i < amountOfClouds; i++)
        {
            SpawnCloud();
        }

        // then start spawning clouds at the specified interval
        //InvokeRepeating("SpawnCloud", spawnInterval, spawnInterval);
    }

    public void SpawnCloud()
    {
        // create a new cloud and set its position and movement speed
        GameObject cloud = Instantiate(cloudPrefab);

        cloud.transform.position = new Vector3(Random.Range(0, 1000), Random.Range(200, 400), Random.Range(0, 1000));
        float speedX = Random.Range(minSpeed, maxSpeed);
        float speedY = Random.Range(minSpeed, maxSpeed);
        Vector2 speed = new Vector2(speedX, speedY);

        float scale = Random.Range(minScale, maxScale);
        cloud.transform.localScale = new Vector3(15 * scale, 10 * scale, 15 * scale);

        float randomRotation = Random.Range(0, 360);
        cloud.transform.Rotate(0, randomRotation, 0);

        // add a CloudMover component to the cloud and set its speed
        CloudMover mover = cloud.AddComponent<CloudMover>();
        mover.speed = speed;
    }
}
