using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossCharacter : EnemyCharacter
{
    public override void Hitted(float damage)
    {
        base.Hitted(damage);

        if (!PlayerCharacter.Instance.IsAlive)
            return;

            if (nowState == EnemyState.Idle)
        {
            ChangeState(EnemyState.Move);
        }





    }
}
