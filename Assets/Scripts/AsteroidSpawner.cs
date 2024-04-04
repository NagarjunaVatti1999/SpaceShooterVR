using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Size of Spawn Area")]
    public Vector3 spawnArea;
    [Header("Rate of Spawn")]
    public float spawnRate = 1f;

    [Header("Model to Spawn")]
    [SerializeField] GameObject asteroid;

    private float spawnTimer = 0f;
    
    private void OnDrawGizmos() {
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawCube(transform.localPosition, spawnArea);
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer>spawnRate)
        {
            SpawnAsteroid();
            spawnTimer = 0;
        }

    }

    private void SpawnAsteroid()
    {
        Vector3 pos = transform.position + new Vector3(UnityEngine.Random.Range(-spawnArea.x/2, spawnArea.x/2),
                                UnityEngine.Random.Range(-spawnArea.y/2, spawnArea.y/2),
                                UnityEngine.Random.Range(-spawnArea.z/2, spawnArea.z/2));
        
        Instantiate(asteroid, pos, transform.rotation, this.transform);
    }
}
