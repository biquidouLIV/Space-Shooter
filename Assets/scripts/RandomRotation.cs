using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(1,4), Random.Range(1,4), Random.Range(1,4)); 
    }

}
