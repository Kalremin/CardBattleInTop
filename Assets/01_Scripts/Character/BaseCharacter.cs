using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseCharacter : MonoBehaviour, ICharacterAct
{

    [SerializeField] protected bool isAlive = true;
    [SerializeField] protected float healthPoint =5;
    [SerializeField] protected float mamaPoint =3;
    [SerializeField] protected float healthRegen=0;
    [SerializeField] protected float manaRegen=0;
    [SerializeField] protected float moveSpeed=1;

    protected delegate void UpdateMethod();
    protected UpdateMethod updateMethod;
    protected Animator animator;

    public bool IsAlive => isAlive;
    public float HealthPoint => healthPoint;
    public float ManaPoint => mamaPoint;

    public float HealthRegen => healthRegen;
    public float ManaRegen => manaRegen;
    public float MoveSpeed => moveSpeed;



    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Move()
    {
        throw new NotImplementedException();
    }

    public virtual void AttackL()
    {
        throw new NotImplementedException();
    }

    public virtual void AttackR()
    {
        throw new NotImplementedException();
    }

    public virtual void Hitted(float damage)
    {
        throw new NotImplementedException();
    }

    public virtual void Idle()
    {
        throw new NotImplementedException();
    }
}
