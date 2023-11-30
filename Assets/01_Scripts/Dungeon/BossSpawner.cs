using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    AssetReference[] bossEnemy;

    // Start is called before the first frame update
    async void Start()
    {
        await bossEnemy[Random.Range(0, bossEnemy.Length)].InstantiateAsync(transform.position,transform.rotation).Task;
    }

}
