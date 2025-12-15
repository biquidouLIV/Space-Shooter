using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.instance.isShieldActive = true;
            Destroy(gameObject);
        }
    }
}
