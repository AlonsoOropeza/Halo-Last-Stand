using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject parent;
    [SerializeField] private int limit = 10;
    [SerializeField] private float rate = 2;

    float spawnTimer;
    void Start()
    {
        spawnTimer = rate;
    }
    void Update()
    {
        if (parent.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation, parent.transform);
                spawnTimer = rate;
            }
        }
    }
}