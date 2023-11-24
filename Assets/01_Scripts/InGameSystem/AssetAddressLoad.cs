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
    AsyncOperationHandle<GameObject> prefabEnemyHandle;

    AsyncOperationHandle<GameObject> prefabUIHandle;


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
    //public async void LoadPrefab(int objectIdx, Transform spawnTransform)
    //{
        
    //    prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab+StaticVar.prefabGameObject + objectIdx);
    //    await prefabHandle.Task;

    //    if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        Instantiate(prefabHandle.Result, spawnTransform);

    //        Addressables.Release(prefabHandle);
    //    }
    //}

    public async void LoadEffect(int objectIdx, Transform spawnTransform)
    {

        prefabHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEffect + objectIdx);
        await prefabHandle.Task;

        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(prefabHandle.Result, spawnTransform.position,spawnTransform.parent.rotation).GetComponent<MagicEffectAttack>().SetIdx(objectIdx);

            Addressables.Release(prefabHandle);
        }
    }

    public async void LoadEnemys(List<int> enemyIdxList, Transform[] spawnTransform, Transform enemyParent)
    {
        for(int i = 0; i < spawnTransform.Length; i++)
        {
            prefabEnemyHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEnemy + enemyIdxList[Random.Range(0,enemyIdxList.Count)]);
            await prefabEnemyHandle.Task;

            if (prefabEnemyHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(prefabEnemyHandle.Result, spawnTransform[i].position, Quaternion.identity).transform.SetParent(enemyParent);

                Addressables.Release(prefabEnemyHandle);
            }
        }
    }



    //public async void LoadUI(int objectIdx, Transform spawnTransform)
    //{
    //    prefabUIHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + objectIdx);
    //    await prefabUIHandle.Task;

    //    if (prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        Instantiate(prefabUIHandle.Result, spawnTransform);

    //        Addressables.Release(prefabUIHandle);
    //    }
    //}


    //public async void LoadSprite(int magicSpriteIdx, Image image)
    //{
    //    spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + magicSpriteIdx);
    //    await spriteHandle.Task;

    //    if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        image.sprite = spriteHandle.Result;

    //        Addressables.Release(spriteHandle);
    //    }
        
    //}

    public async void LoadCardUI(int magicSpriteIdx, Transform spawnTransform)
    {
        prefabUIHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.resPrefabUI + StaticVar.UI_CardIdx);
        spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + magicSpriteIdx);

        await prefabUIHandle.Task;
        await spriteHandle.Task;

        if(spriteHandle.Status == AsyncOperationStatus.Succeeded && 
            prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
        {
            prefabUIHandle.Result.GetComponent<Image>().sprite = spriteHandle.Result;
            Instantiate(prefabUIHandle.Result, spawnTransform);

            Addressables.Release(spriteHandle);
            Addressables.Release(prefabUIHandle);
        }


    }

    public async void LoadCardUIList(List<MagicCard> cardUIList, Transform spawnTransform)
    {

        for(int i = 0; i < cardUIList.Count; i++)
        {
            prefabUIHandle = cardUIList[i].magicUI.LoadAssetAsync<GameObject>();
            await prefabUIHandle.Task;

            if(prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(prefabUIHandle.Result, spawnTransform);
                Addressables.Release(prefabUIHandle);
            }
        }

        //prefabUIHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + StaticVar.UI_CardIdx);
        //await prefabUIHandle.Task;

        //if (prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
        //{
        //    for(int i = 0; i < cardUIList.Count; i++)
        //    {
        //        spriteHandle = Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + cardUIList[i]);
        //        await spriteHandle.Task;

        //        Instantiate()

        //        if (spriteHandle.Status == AsyncOperationStatus.Succeeded)
        //        {
        //            tempImage.sprite = spriteHandle.Result;
        //            Instantiate(tempImage.gameObject, spawnTransform);

        //            Addressables.Release(spriteHandle);
        //        }
        //    }



        //    Addressables.Release(prefabUIHandle);

        //}


    }

    //[ContextMenu("AllRelease")]
    //public void ResAllRelease()
    //{
    //    Addressables.Release(spriteHandle);
    //    Addressables.Release(prefabHandle);

        
    //}

    //[ContextMenu("TestRelease")]
    //public void TestRelease()
    //{
    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabUI + StaticVar.UI_CardIdx));

    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + 0));
    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + 1));
    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<Sprite>(StaticVar.resSprite + StaticVar.spriteMagic + 2));

    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabGameObject + 0));
    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabGameObject + 1));
    //    Addressables.Release(
    //        Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabGameObject + 2));
    //}


    //[ContextMenu("SpriteRelease")]
    //public void SpriteRelease()
    //{
    //    Addressables.Release(spriteHandle);
    //}

    //[ContextMenu("PrefabRelease")]
    //public void PrefabRelease()
    //{
    //    Addressables.Release(prefabHandle);
    //}

}
