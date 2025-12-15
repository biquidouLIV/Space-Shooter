using System.Collections;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Vector3 direction;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }

}
