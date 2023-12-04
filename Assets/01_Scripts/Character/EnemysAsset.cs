using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class Enemy
{
    public int idx;
    public AssetReference prefabRef;
}

public class EnemysAsset : MonoBehaviour
{
    static EnemysAsset instance;
    public static EnemysAsset Instance=>instance;


    [SerializeField] List<Enemy> enemies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Enemy GetEnemy(int idx) => enemies[idx];

    public int GetEnemysCount => enemies.Count;
}
