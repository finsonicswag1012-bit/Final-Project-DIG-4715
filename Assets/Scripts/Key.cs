using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject doorLock;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(doorLock);
        Destroy(gameObject);
    }
}
