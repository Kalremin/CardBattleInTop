using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class SoundClass
{
    public AssetReference prefabSound;
    public string description;
}

public class SoundsAsset : MonoBehaviour
{
    [SerializeField] List<SoundClass> soundClasses;

    static SoundsAsset instance;
    public static SoundsAsset Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public SoundClass GetSound(int idx) => soundClasses[idx];

    public int CountSoundClasses => soundClasses.Count;
}
