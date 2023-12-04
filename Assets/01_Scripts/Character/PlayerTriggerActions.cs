using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerActions : MonoBehaviour
{
    bool isHit = false;
    public bool IsHit=>isHit;

    public void UseCardMagicL()
    {
        CardPlayer.Instance.UseCard(true, PlayerCharacter.Instance.ManaPoint);
    }

    public void UseCardMagicR()
    {
        CardPlayer.Instance.UseCard(false, PlayerCharacter.Instance.ManaPoint);
    }

    public void IsHitting(int val)
    {
        isHit = val > 0 ? true : false;
    }
}
