using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ICharacterAct
    public override void AttackL()
    {
        throw new System.NotImplementedException();
    }

    public override void AttackR()
    {
        throw new System.NotImplementedException();
    }

    public override void Hitted(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Idle()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
