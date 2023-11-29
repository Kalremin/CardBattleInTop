using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    static ObjectPooling instance;
    public static ObjectPooling Instance => instance;

    Dictionary<string, Queue<GameObject>[]> poolingDic;
    Dictionary<int, Queue<GameObject>> effectPoolingDic;

    //temp
    Queue<GameObject>[] enemyQueue;
    Queue<GameObject>[] effectQueue;


    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        poolingDic = new Dictionary<string, Queue<GameObject>[]>();
        effectPoolingDic = new Dictionary<int, Queue<GameObject>>();
    }


    public void InstantiateEffect(int effectIdx,Transform spawnTransform)
    {
        GameObject tempGo;

        if (!effectPoolingDic.ContainsKey(effectIdx))
        {
            effectPoolingDic.Add(effectIdx, new Queue<GameObject>());
        }

        if (effectPoolingDic[effectIdx].Count > 0)
        {
            tempGo = effectPoolingDic[effectIdx].Dequeue();
            tempGo.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            tempGo.SetActive(true);
        }
        else
        {
            //Instantiate(CardsAsset.Instance.GetMagic(effectIdx).objEffect, spawnTransform.position,spawnTransform.rotation).GetComponent<MagicEffectAttack>().SetIdx(effectIdx);
            AssetAddressLoad.Instance.LoadEffect(effectIdx, spawnTransform);
        }


    }

    public void ReturnEffect(GameObject effectObject,int effectIdx)
    {

        effectObject.SetActive(false);
        effectObject.transform.SetParent(transform);

        effectPoolingDic[effectIdx].Enqueue(effectObject);
    }



}
