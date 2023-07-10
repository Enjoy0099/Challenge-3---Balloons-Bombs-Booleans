using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 1.5f;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = FindObjectOfType<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            // Set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(transform.position.x, Random.Range(3, 15), transform.position.z);
            int index = Random.Range(0, objectPrefabs.Length);

            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
