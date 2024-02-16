using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorTrigger : MonoBehaviour
{
    [SerializeField]
    BossSpawner bossSpawner;

    [SerializeField]
    GameObject hideRoofs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossSpawner.CloseDoor();
            hideRoofs.SetActive(false);
        }
    }

}
