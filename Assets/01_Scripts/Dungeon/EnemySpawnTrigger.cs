using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    
    public RoomEnemyControl spawn;

    [SerializeField] GameObject hideRoofs;

    private void Awake()
    {
        spawn = GetComponentInParent<RoomEnemyControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            hideRoofs.SetActive(false);

            spawn.Spawn();
        }
    }
}
