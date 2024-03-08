using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPref : MonoBehaviour
{
    [SerializeField] int idx;

    AudioSource playingAudioSource;

    float elapsedTime = 0;
    float audioTime;

    // Start is called before the first frame update
    void Start()
    {
        playingAudioSource = GetComponent<AudioSource>();
        audioTime = playingAudioSource.clip.length+0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= audioTime)
        {
            elapsedTime = 0;
            ObjectPooling.Instance.ReturnSound(gameObject, idx);
        }
        else
            elapsedTime += Time.deltaTime;
    }
}
