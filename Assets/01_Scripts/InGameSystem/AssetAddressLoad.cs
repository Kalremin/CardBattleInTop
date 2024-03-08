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
    AsyncOperationHandle<GameObject> prefabSoundHandle;
    AsyncOperationHandle<Material> materialHandle;

    Dictionary<string, AsyncOperationHandle<GameObject>> totalHandleDic = new Dictionary<string, AsyncOperationHandle<GameObject>>();

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
        if (!totalHandleDic.ContainsKey(CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID))
        {
            totalHandleDic.Add(CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID,
                //Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEffect + objectIdx));
                CardsAsset.Instance.GetMagic(objectIdx).magicEffect.LoadAssetAsync<GameObject>());
            prefabHandle = totalHandleDic[CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID];
            await prefabHandle.Task;
        }
        else
        {
            prefabHandle = totalHandleDic[CardsAsset.Instance.GetMagic(objectIdx).magicEffect.AssetGUID];

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
            if (!totalHandleDic.ContainsKey(tempEnemy.prefabRef.AssetGUID))
            {
                totalHandleDic.Add(tempEnemy.prefabRef.AssetGUID, tempEnemy.prefabRef.LoadAssetAsync<GameObject>());
                prefabEnemyHandle = totalHandleDic[tempEnemy.prefabRef.AssetGUID];
                await prefabEnemyHandle.Task;
            }
            else
            {
                prefabEnemyHandle = totalHandleDic[tempEnemy.prefabRef.AssetGUID];
            }

            if(prefabEnemyHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(prefabEnemyHandle.Result, spawnTransform.Dequeue().position, Quaternion.identity).transform.SetParent(enemyParent);
            }
            

        }

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

            if (!totalHandleDic.ContainsKey(cardUIList[i].magicUI.AssetGUID))
            {
                totalHandleDic.Add(cardUIList[i].magicUI.AssetGUID, cardUIList[i].magicUI.LoadAssetAsync<GameObject>());
                prefabUIHandle = totalHandleDic[cardUIList[i].magicUI.AssetGUID];
                await prefabUIHandle.Task;
            }
            else
            {
                prefabUIHandle = totalHandleDic[cardUIList[i].magicUI.AssetGUID];

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

    public async void LoadSound(int objectIdx, Transform spawnTransform)
    {
        if (!totalHandleDic.ContainsKey(SoundsAsset.Instance.GetSound(objectIdx).prefabSound.AssetGUID))
        {
            totalHandleDic.Add(SoundsAsset.Instance.GetSound(objectIdx).prefabSound.AssetGUID,
                //Addressables.LoadAssetAsync<GameObject>(StaticVar.resPrefab + StaticVar.prefabEffect + objectIdx));
                SoundsAsset.Instance.GetSound(objectIdx).prefabSound.LoadAssetAsync<GameObject>());
            prefabSoundHandle = totalHandleDic[SoundsAsset.Instance.GetSound(objectIdx).prefabSound.AssetGUID];
            await prefabSoundHandle.Task;
        }
        else
        {
            prefabSoundHandle = totalHandleDic[SoundsAsset.Instance.GetSound(objectIdx).prefabSound.AssetGUID];

        }


        if (prefabSoundHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(prefabSoundHandle.Result, spawnTransform.position, spawnTransform.parent.rotation).GetComponent<MagicEffectAttack>().SetIdx(objectIdx);

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
        foreach(string temp in totalHandleDic.Keys)
        {
            Addressables.Release(totalHandleDic[temp]);
        }
    }

}
