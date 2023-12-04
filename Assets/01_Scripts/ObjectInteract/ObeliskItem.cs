using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskItem : ItemInDungeon
{

    public override void ActivateInteraction()
    {
        if (used) 
            return;
        PlayerCharacter.Instance.RestoreHealthPoint(PlayerCharacter.Instance.MaxHealthPoint / 2);
        eventItem.Invoke();
        used = true;

    }
}
