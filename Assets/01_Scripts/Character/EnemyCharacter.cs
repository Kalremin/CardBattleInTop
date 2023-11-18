using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter, ICharacterAct
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
    public void AttackL()
    {
        throw new System.NotImplementedException();
    }

    public void AttackR()
    {
        throw new System.NotImplementedException();
    }

    public void Hitted(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
