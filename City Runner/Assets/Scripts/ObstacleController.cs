using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (other.CompareTag("Player"))
        {
            rb.isKinematic = true;
        }else rb.isKinematic = false;
    }
}
