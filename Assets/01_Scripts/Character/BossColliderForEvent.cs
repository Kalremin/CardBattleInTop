using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BossColliderForEvent : MonoBehaviour
{
    [SerializeField] float damage = 3;
    
    bool isPlayerin = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter player))
        {
            isPlayerin = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter player))
        {
            isPlayerin = false;
        }
    }

    public void HitPlayer()
    {
        if (isPlayerin)
            PlayerCharacter.Instance.Hitted(damage);

    }
}
