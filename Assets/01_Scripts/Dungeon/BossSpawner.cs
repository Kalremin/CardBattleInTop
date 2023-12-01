using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    AssetReference[] bossEnemy;

    [SerializeField]
    Transform spawnerTransform;

    AsyncOperationHandle<GameObject> tempHandle;

    // Start is called before the first frame update
    async void Start()
    {
        tempHandle = bossEnemy[Random.Range(0, bossEnemy.Length)].LoadAssetAsync<GameObject>();

        await tempHandle.Task;

        if(tempHandle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            Instantiate(tempHandle.Result, spawnerTransform.position, spawnerTransform.rotation);

            
        }
    }

}
