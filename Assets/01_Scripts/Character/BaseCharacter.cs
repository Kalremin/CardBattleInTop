using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, ICharacterAct
{
    protected CharacterController characterController;
    protected Animator animator;

    #region Cycle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Interface

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Hitted()
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
