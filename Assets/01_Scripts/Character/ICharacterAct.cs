using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAct
{
    public abstract void Move();
    public abstract void AttackL();
    public abstract void AttackR();
    public abstract void Hitted(float damage);
    public abstract void Idle();


}
