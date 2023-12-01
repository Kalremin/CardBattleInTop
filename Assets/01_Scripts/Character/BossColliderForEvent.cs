using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderForEvent : MonoBehaviour
{
    [SerializeField] float damage = 3;
    List<PlayerCharacter> playerList = new List<PlayerCharacter>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter player))
        {
            playerList.Add(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter player))
        {
            playerList.Remove(player);
        }
    }

    public void HitPlayer()
    {
        foreach(var temp in playerList)
        {
            temp.Hitted(damage);
        }
    }
}
