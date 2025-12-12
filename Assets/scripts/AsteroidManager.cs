using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject asteroid1;
    [SerializeField] GameObject asteroid2;
    [SerializeField] GameObject asteroid3;
    [SerializeField] GameObject AsteroidSpawner;
    
    [SerializeField] float spawnDelay = 1f;
    float lastAsteroidSpawn;

    float a;
  
    void Update()
    {
        if (Time.time - spawnDelay > lastAsteroidSpawn)
        {
            a = Random.value;

            if (a <= 0.4f)
            {
                Instantiate(asteroid1, AsteroidSpawner.transform.position, Quaternion.identity);
            }
            else if (a >=0.8f)
            {
                Instantiate(asteroid2, AsteroidSpawner.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(asteroid3, AsteroidSpawner.transform.position, Quaternion.identity);
            }

            Vector3 asteroidPosition = new Vector3(Random.Range(4, -4), 0, gameObject.transform.position.z);
            transform.position = asteroidPosition;
            lastAsteroidSpawn = Time.time;
        }
    }
}
