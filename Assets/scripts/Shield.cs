
using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "asteroid")
        {
            Destroy(other.gameObject);
            PlayerController.instance.isShieldActive = false;
            gameObject.SetActive(false);
        }

    }
}
