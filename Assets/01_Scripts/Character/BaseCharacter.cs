using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BaseCharacter : MonoBehaviour
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

    public abstract void Move();

    public abstract void AttackL();

    public abstract void AttackR();

    public abstract void Hitted(float damage);

    public abstract void Idle();
}
