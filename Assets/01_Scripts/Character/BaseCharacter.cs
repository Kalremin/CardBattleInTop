using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, ICharacterAct
{
    int healthPoint;
    int mamaPoint;
    float healthRegen;
    float manaRegen;
    float moveSpeed;



    protected Animator animator;

    #region Cycle


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    #endregion

    #region Interface

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Hitted()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Idle()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
