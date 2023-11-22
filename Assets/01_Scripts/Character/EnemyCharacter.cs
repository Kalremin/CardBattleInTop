using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyCharacter : BaseCharacter
{
    public enum EnemyState
    {
        Idle,
        Move,
        Attack
    }

    EnemyState nowState;

    
    NavMeshAgent navAgent;
    PlayerCharacter playerCharacter;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        playerCharacter = FindFirstObjectByType<PlayerCharacter>();
        ChangeState(EnemyState.Move);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case EnemyState.Idle:

                break;
            case EnemyState.Move:
                if (Vector3.Distance(transform.position, playerCharacter.NavTargetVec) < 1)
                    ChangeState(EnemyState.Attack);

                navAgent.destination = playerCharacter.transform.position;

                break;
            case EnemyState.Attack:
                if (Vector3.Distance(transform.position, playerCharacter.NavTargetVec) > 1)
                    ChangeState(EnemyState.Move);

                if (!playerCharacter.IsAlive)
                    ChangeState(EnemyState.Idle);
                break;
        }
    }


    public void ChangeState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                navAgent.isStopped = true;

                break;
            case EnemyState.Move:
                
                navAgent.isStopped = false;
                //animator.SetBool("Move", true);
                break;
            case EnemyState.Attack:
                navAgent.isStopped = true;
                //animator.SetBool("Move", false);
                //animator.SetBool("Attack", true);
                break; ;
        }

        nowState = state;
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
