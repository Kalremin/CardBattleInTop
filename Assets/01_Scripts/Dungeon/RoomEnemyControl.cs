using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public enum BattleState
{
    Ready,
    Battle,
    Clear
}


public class RoomEnemyControl : MonoBehaviour
{
    public static int countEnemies=0;
    [SerializeField] Transform[] enemySpawner;
    [SerializeField] GameObject[] battleDoors;
    [SerializeField] Transform enemyGroupTransform;

    Queue<Enemy> enemyIdxList = new Queue<Enemy>();
    Queue<Transform> spawnerQueue = new Queue<Transform>();
    BattleState nowState=BattleState.Ready;


    
    void Start()
    {
        
        
        for(int i = 0; i < Random.Range(1, enemySpawner.Length + 1); i++)
        {
            enemyIdxList.Enqueue(
                EnemysAsset.Instance.GetEnemy(Random.Range(0,EnemysAsset.Instance.GetEnemysCount))
                );
        }

        foreach(var temp in enemySpawner)
        {
            spawnerQueue.Enqueue(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case BattleState.Ready:

                break;
            case BattleState.Battle:
                if (countEnemies <= 0)
                {
                    OpenDoor();
                }

                break;
            case BattleState.Clear:
                Destroy(this);
                break;
        }
    }

    public void Spawn()
    {
        if (nowState != BattleState.Ready)
            return;
        nowState = BattleState.Battle;

        countEnemies = enemyIdxList.Count;

        

        foreach (var temp in battleDoors)
        {
            if(temp!=null)
                temp.SetActive(true);
        }
        
        AssetAddressLoad.Instance.LoadEnemys(enemyIdxList, spawnerQueue, enemyGroupTransform);
    }

    public void OpenDoor()
    {
        nowState = BattleState.Clear;
        foreach (var temp in battleDoors)
        {
            if (temp != null)
                temp.SetActive(false);
        }
    }

    

}
