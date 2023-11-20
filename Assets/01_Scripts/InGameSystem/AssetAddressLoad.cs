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

    public async void LoadUI(int objectIdx, Transform spawnTransform)
    {
        prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + objectIdx);
        await prefabHandle.Task;

        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(prefabHandle.Result, spawnTransform);

            Addressables.Release(prefabHandle);
        }
    }


    public async void LoadSprite(int magicSpriteIdx, Image image)
    {
        spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + magicSpriteIdx);
        await spriteHandle.Task;

        if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
        {
            image.sprite = spriteHandle.Result;

            Addressables.Release(spriteHandle);
        }
        
    }

    public async void LoadCardUI(int magicSpriteIdx, Transform spawnTransform)
    {
        prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + StaticVar.UI_CardIdx);
        spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + magicSpriteIdx);

        await prefabHandle.Task;
        await spriteHandle.Task;

        if(spriteHandle.Status == AsyncOperationStatus.Succeeded && 
            prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            prefabHandle.Result.GetComponent<Image>().sprite = spriteHandle.Result;
            Instantiate(prefabHandle.Result, spawnTransform);

            Addressables.Release(spriteHandle);
            Addressables.Release(prefabHandle);
        }


    }

    public async void LoadCardUIList(List<int> cardUIList, Transform spawnTransform)
    {
        prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + StaticVar.UI_CardIdx);
        await prefabHandle.Task;

        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            for(int i = 0; i < cardUIList.Count; i++)
            {
                spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + cardUIList[i]);
                await spriteHandle.Task;
                Image tempImage = prefabHandle.Result.GetComponent<Image>();
                tempImage.sprite = spriteHandle.Result;
                Instantiate(tempImage.gameObject, spawnTransform);

            }



            Addressables.Release(spriteHandle);
            Addressables.Release(prefabHandle);
        }


    }


    [ContextMenu("Release")]
    public void ResRelease()
    {
        Addressables.Release(spriteHandle);
        Addressables.Release(prefabHandle);
    }
}
