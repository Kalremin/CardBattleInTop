using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class AssetAddressLoad : MonoBehaviour
{

    static AssetAddressLoad instance;
    public static AssetAddressLoad Instance => instance;

    AsyncOperationHandle<Sprite> spriteHandle;

    AsyncOperationHandle<GameObject> prefabHandle;

    private void Start()
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


    public async void LoadPrefab(int objectIdx, Transform spawnTransform)
    {
        prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab+StaticVar.prefabGameObject + objectIdx);
        await prefabHandle.Task;

        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(prefabHandle.Result, spawnTransform);

            Addressables.Release(prefabHandle);
        }
    }


    public async void LoadSprite(int magicIdx, Image image)
    {
        spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + magicIdx);
        await spriteHandle.Task;

        if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
        {
            image.sprite = spriteHandle.Result;

            Addressables.Release(spriteHandle);
        }
        
    }
    [ContextMenu("Release")]
    public void ResRelease()
    {
        Addressables.Release(spriteHandle);
        Addressables.Release(prefabHandle);
    }
}
