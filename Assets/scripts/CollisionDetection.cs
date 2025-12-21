using UnityEngine;

public class CollisionDetection : MonoBehaviour { 

    [SerializeField] GameObject asteroidExplosionVFX;
    [SerializeField] GameObject PlayerExplosionVFX;


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "laser")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
            GameManager.instance.ScoreUpdate();
      
        }

        else if (collision.gameObject.tag =="Player")
        {
            if (PlayerController.instance.isShieldActive)
            {
                PlayerController.instance.isShieldActive = false;
            }
            else
            {
                Destroy(collision.gameObject);

                Instantiate(PlayerExplosionVFX, transform.position, Quaternion.identity);
                GameManager.instance.GameOver();
            }
            Destroy(gameObject);
        }
    }
    
    



}
