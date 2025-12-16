using System;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "asteroid")
        {
            GameManager.instance.ScoreUpdate();
            Destroy(other.gameObject);
            Destroy(gameObject, 0.3f);
        }
    }
}
