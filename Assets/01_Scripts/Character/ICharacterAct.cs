using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAct
{
    public abstract void Move();
    public abstract void Attack();
    public abstract void Hitted();
    public abstract void Idle();


}
