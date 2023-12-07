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

    [SerializeField]
    GameObject[] doors;

    BossCharacter character;

    bool isTrigger = false;
    AsyncOperationHandle<GameObject> tempHandle;

    // Start is called before the first frame update
    async void Start()
    {
        tempHandle = bossEnemy[Random.Range(0, bossEnemy.Length)].LoadAssetAsync<GameObject>();

        await tempHandle.Task;

        if(tempHandle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            character = Instantiate(tempHandle.Result, spawnerTransform.position, spawnerTransform.rotation).GetComponent<BossCharacter>();

            
        }

        

    }

    private void Update()
    {
        if(character != null && !character.IsAlive)
        {
            Addressables.Release(tempHandle);
            OpenDoor();
            character = null;
        }
    }

    public void CloseDoor()
    {
        if (isTrigger)
            return;

        foreach(var temp in doors)
        {
            if(temp!=null)
                temp.gameObject.SetActive(true);
        }
        isTrigger = true;
    }

    public void OpenDoor()
    {
        foreach (var temp in doors)
        {
            if (temp != null)
                temp.gameObject.SetActive(false);
        }
    }




}
