using System;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    [SerializeField] private GameObject VFX;   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "asteroid")
        {
            GameManager.instance.ScoreUpdate();
            Instantiate(VFX, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject, 1.5f);
        }
    }
}
