using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    
    public RoomEnemyControl spawn;

    private void Awake()
    {
        spawn = GetComponentInParent<RoomEnemyControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            spawn.Spawn();
        }
    }
}
