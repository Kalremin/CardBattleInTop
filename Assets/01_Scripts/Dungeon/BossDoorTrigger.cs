using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorTrigger : MonoBehaviour
{
    [SerializeField]
    BossSpawner bossSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossSpawner.CloseDoor();
        }
    }

}
