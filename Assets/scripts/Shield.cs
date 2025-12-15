
using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "asteroid")
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }

    }
}
