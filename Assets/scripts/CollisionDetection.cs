using UnityEngine;

public class CollisionDetection : MonoBehaviour { 

    [SerializeField] GameObject asteroidExplosionVFX;
    [SerializeField] GameObject PlayerExplosionVFX;


    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "laser")
        {
            Destroy(gameObject);
            Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
            GameManager.instance.ScoreUpdate();
      
        }

        else if (collision.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            Instantiate(PlayerExplosionVFX, transform.position, Quaternion.identity);
            GameManager.instance.GameOver();
        }

      
    }


}
