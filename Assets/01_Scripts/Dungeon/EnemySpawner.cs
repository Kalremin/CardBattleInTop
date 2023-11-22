using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    RoomEnemyControl roomEnemyManager;
    GameObject enemy;
    GameObject temp;
    bool isSpawned = false;
    bool isClear = false;

    private void Awake()
    {
        roomEnemyManager = transform.parent.parent.GetComponent<RoomEnemyControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SetEnemy(GameObject go) => enemy = go;

    public void Spawn() 
    {
        
    }
}
