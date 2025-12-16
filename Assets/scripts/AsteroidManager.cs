using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject oiseau;
    [SerializeField] GameObject poisson;
    [SerializeField] GameObject shieldCollectible;
    [SerializeField] GameObject AsteroidSpawner;
    
    [SerializeField] float spawnDelay = 1f;
    float lastAsteroidSpawn;

    private void Start()
    {
        StartCoroutine(IncreasingDifficulty());
    }

    void Update()
    {
        if (Time.time - spawnDelay > lastAsteroidSpawn)
        {
            float a = Random.value;
            switch (a)
            {
                
                case > 0.97f:
                    Instantiate(shieldCollectible, AsteroidSpawner.transform.position, Quaternion.identity);
                    break;
                case > 0.30f:
                    Instantiate(poisson, AsteroidSpawner.transform.position, Quaternion.identity);
                    break;
                default:
                    Instantiate(oiseau, AsteroidSpawner.transform.position, Quaternion.identity);
                    break;

            }

            Vector3 asteroidPosition = new Vector3(Random.Range(4, -4), 0, gameObject.transform.position.z);
            transform.position = asteroidPosition;
            lastAsteroidSpawn = Time.time;
        }
    }
    
    private IEnumerator IncreasingDifficulty()
    {
        spawnDelay = spawnDelay * 0.90f;
        Debug.Log(spawnDelay);
        yield return new WaitForSeconds(5);
        StartCoroutine(IncreasingDifficulty());
    }
}
