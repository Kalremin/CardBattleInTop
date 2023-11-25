using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class MagicCard
{
    public int idx;
    public int costManaPoint;
    public AssetReference magicUI;
    public AssetReference magicEffect;
    public bool isArea = false;
    public string description;
}

public class CardsAsset : MonoBehaviour
{
    static CardsAsset instance;
    public static CardsAsset Instance=>instance;

    

    [SerializeField] List<MagicCard> magicCards;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public MagicCard GetMagic(int idx) => magicCards[idx];

}
