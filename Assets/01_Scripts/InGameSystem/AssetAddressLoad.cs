using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public enum MagicKind
{
    FireMage,
    IceMage,
    EarthMage
}

public class AssetAddressLoad : MonoBehaviour
{
    static AssetAddressLoad instance;
    public static AssetAddressLoad Instance => instance;

    AsyncOperationHandle<Sprite> spriteHandle;

    AsyncOperationHandle<GameObject> gameObjectHandle;

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


    public async void LoadGameObject(string name,int objectIdx, Transform spawnTransform)
    {
        gameObjectHandle = Addressables.LoadAssetAsync<GameObject>(name + objectIdx);
        await gameObjectHandle.Task;

        if (gameObjectHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(gameObjectHandle.Result, spawnTransform);
        }
    }


    public async void LoadSprite(MagicKind kind, int magicIdx, Image image)
    {
        spriteHandle = Addressables.LoadAssetAsync<Sprite>(kind.ToString() + magicIdx);
        await spriteHandle.Task;

        if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
        {
            image.sprite = spriteHandle.Result;
        }
        
    }
    [ContextMenu("Release")]
    public void ResRelease()
    {
        Addressables.Release(spriteHandle);
        Addressables.Release(gameObjectHandle);
    }
}
