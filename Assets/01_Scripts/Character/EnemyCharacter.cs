using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCharacter : BaseCharacter
{
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Die
    }

    EnemyState nowState;

    
    NavMeshAgent navAgent;
    PlayerCharacter playerCharacter;

    [SerializeField] protected float detectDistance = 50;
    [SerializeField] protected float attackRange = 1;
    [SerializeField] protected Transform modelTransform;

    public GameObject lockOnGround;
    


    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        playerCharacter = FindFirstObjectByType<PlayerCharacter>();
        ChangeState(EnemyState.Move);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        

        switch (nowState)
        {
            case EnemyState.Idle:
                if (playerCharacter.IsAlive && Vector3.Distance(transform.position, playerCharacter.NavTargetVec) < detectDistance)
                    ChangeState(EnemyState.Move);
                    break;
            case EnemyState.Move:
                if (Vector3.Distance(transform.position, playerCharacter.NavTargetVec) < attackRange)
                    ChangeState(EnemyState.Attack);

                navAgent.destination = playerCharacter.transform.position;


                break;
            case EnemyState.Attack:
                if (!playerCharacter.IsAlive)
                    ChangeState(EnemyState.Idle);
                if (Vector3.Distance(transform.position, playerCharacter.NavTargetVec) > attackRange)
                    ChangeState(EnemyState.Move);


                
                

                break;
        }
    }


    public void ChangeState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                navAgent.isStopped = true;
                animator.SetBool("Move", false);
                animator.SetBool("Attack", false);
                break;
            case EnemyState.Move:
                navAgent.isStopped = false;
                animator.SetBool("Move",true);
                animator.SetBool("Attack", false);
                break;
            case EnemyState.Attack:
                navAgent.isStopped = true;
                animator.SetBool("Attack", true);
                animator.SetBool("Move", false);
                
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
        healthPoint -= damage;
        animator.SetTrigger("Hit");
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
