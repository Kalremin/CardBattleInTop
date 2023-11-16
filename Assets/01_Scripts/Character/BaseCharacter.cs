using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

    [SerializeField] bool isAlive = true;
    [SerializeField] int healthPoint=5;
    [SerializeField] int mamaPoint=3;
    [SerializeField] float healthRegen=0;
    [SerializeField] float manaRegen=0;
    [SerializeField] float moveSpeed=1;

    protected delegate void UpdateMethod();
    protected UpdateMethod updateMethod;
    protected Animator animator;

    public int HealthPoint => healthPoint;
    public int ManaPoint => mamaPoint;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (isAlive)
        {
            
        }
        else
        {

        }
    }

    

    
}
