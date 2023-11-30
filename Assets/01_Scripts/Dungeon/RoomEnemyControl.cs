using System.Collections;
using System.Collections.Generic;
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

    int count;
    
    [SerializeField] Transform[] enemySpawner;
    [SerializeField] GameObject[] battleDoors;
    [SerializeField] Transform enemyGroupTransform;

    List<int> enemyIdxList = new List<int>();
    BattleState nowState=BattleState.Ready;


    
    void Start()
    {
        enemyIdxList.Add(0);
        count = enemySpawner.Length;
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case BattleState.Ready:

                break;
            case BattleState.Battle:
                if (count <= 0)
                {
                    OpenDoor();
                }

                break;
            case BattleState.Clear:
                break;
        }
    }

    public void Spawn()
    {
        if (nowState != BattleState.Ready)
            return;
        nowState = BattleState.Battle;

        foreach(var temp in battleDoors)
        {
            if(temp!=null)
                temp.SetActive(true);
        }

        AssetAddressLoad.Instance.LoadEnemys(enemyIdxList, enemySpawner, enemyGroupTransform);
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
