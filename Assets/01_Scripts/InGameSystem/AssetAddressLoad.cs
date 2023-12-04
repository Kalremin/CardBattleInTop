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
    AsyncOperationHandle<Material> materialHandle;

    Dictionary<string, AsyncOperationHandle<GameObject>> tempDic = new Dictionary<string, AsyncOperationHandle<GameObject>>();

    int temp;
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
        if (!tempDic.ContainsKey(CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID))
        {
            tempDic.Add(CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID,
                //Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEffect + objectIdx));
                CardsAsset.Instance.GetMagic(objectIdx).magicEffect.LoadAssetAsync<GameObject>());
            prefabHandle = tempDic[CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID];
            await prefabHandle.Task;
        }
        else
        {
            prefabHandle = tempDic[CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID];

        }


        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(prefabHandle.Result, spawnTransform.position,spawnTransform.parent.rotation).GetComponent<MagicEffectAttack>().SetIdx(objectIdx);

            //Addressables.Release(prefabHandle);
        }
    }

    public async void LoadEnemys(Queue<Enemy> enemyIdxList, Queue<Transform> spawnTransform, Transform enemyParent)
    {
        while (enemyIdxList.Count > 0)
        {
            Enemy tempEnemy = enemyIdxList.Dequeue();
            if (!tempDic.ContainsKey(tempEnemy.prefabRef.AssetGUID))
            {
                tempDic.Add(tempEnemy.prefabRef.AssetGUID, tempEnemy.prefabRef.LoadAssetAsync<GameObject>());
                prefabEnemyHandle = tempDic[tempEnemy.prefabRef.AssetGUID];
                await prefabEnemyHandle.Task;
            }
            else
            {
                prefabEnemyHandle = tempDic[tempEnemy.prefabRef.AssetGUID];
            }

            if(prefabEnemyHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(prefabEnemyHandle.Result, spawnTransform.Dequeue().position, Quaternion.identity).transform.SetParent(enemyParent);
            }
            

        }


        //for(int i = 0; i < spawnTransform.Length; i++)
        //{
        //    temp = Random.Range(0,enemyIdxList.Count);
        //    prefabEnemyHandle = Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEnemy + enemyIdxList[Random.Range(0,temp)]);
        //    await prefabEnemyHandle.Task;

        //    if (prefabEnemyHandle.Status == AsyncOperationStatus.Succeeded)
        //    {
        //        Instantiate(prefabEnemyHandle.Result, spawnTransform[i].position, Quaternion.identity).transform.SetParent(enemyParent);


        //        Addressables.Release(prefabEnemyHandle);
        //    }
        //}
    }

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
        for (int i = 0; i < cardUIList.Count; i++)
        {

            if (!tempDic.ContainsKey(cardUIList[i].magicUI.AssetGUID))
            {
                tempDic.Add(cardUIList[i].magicUI.AssetGUID, cardUIList[i].magicUI.LoadAssetAsync<GameObject>());
                prefabUIHandle = tempDic[cardUIList[i].magicUI.AssetGUID];
                await prefabUIHandle.Task;
            }
            else
            {
                prefabUIHandle = tempDic[cardUIList[i].magicUI.AssetGUID];

            }
                //prefabUIHandle = cardUIList[i].magicUI.InstantiateAsync(spawnTransform);
            
            

            if (prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
            {

                //Addressables.ReleaseInstance(prefabUIHandle.Result);
                //print(cardUIList[i].magicUI.AssetGUID);
                //tempQueue.Enqueue(prefabUIHandle);

                Instantiate(prefabUIHandle.Result, spawnTransform);
                //Addressables.ReleaseInstance(prefabUIHandle);
            }
        }

    }

    //public async void LoadCardUIList(List<MagicCard> cardUIList, Transform spawnTransform)
    //{

    //    for(int i = 0; i < cardUIList.Count; i++)
    //    {
    //        prefabUIHandle = cardUIList[i].magicUI.LoadAssetAsync<GameObject>();
    //        await prefabUIHandle.Task;

    //        if(prefabUIHandle.Status == AsyncOperationStatus.Succeeded)
    //        {
    //            Instantiate(prefabUIHandle.Result, spawnTransform);
    //            Addressables.Release(prefabUIHandle);
    //        }
    //    }

    //}

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


    [ContextMenu("PrefabUIRelease")]
    public void PrefabRelease()
    {
        //Addressables.Release(tempQueue.Dequeue());
    }

    public void ReleaseAll()
    {
        foreach(string temp in tempDic.Keys)
        {
            Addressables.Release(tempDic[temp]);
        }
    }

}
