using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject hideRoofs;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            hideRoofs.SetActive(false);
        }
    }
}
