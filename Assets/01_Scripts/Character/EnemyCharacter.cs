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
        Die,
        None
    }

    protected EnemyState nowState;

    
    NavMeshAgent navAgent;
    

    [SerializeField] protected float detectDistance = 50;
    [SerializeField] protected float attackRange = 1;
    [SerializeField] protected Transform modelTransform;
    [SerializeField] protected EnemyColliderForEvent enemyAniEvent;
    [SerializeField] protected BossColliderForEvent bossAniEvent;

    public GameObject lockOnGround;
    


    protected override void Awake()
    {
        
        
        navAgent = GetComponent<NavMeshAgent>();
        
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
                if (PlayerCharacter.Instance.IsAlive && Vector3.Distance(transform.position, PlayerCharacter.Instance.playerModelPos) < detectDistance)
                    ChangeState(EnemyState.Move);
                    break;
            case EnemyState.Move:
                if(enemyAniEvent != null && enemyAniEvent.IsHit)
                {
                    navAgent.isStopped = true;
                    return;
                }

                navAgent.isStopped = false;
                if (Vector3.Distance(transform.position, PlayerCharacter.Instance.playerModelPos) < attackRange)
                    ChangeState(EnemyState.Attack);

                navAgent.destination = PlayerCharacter.Instance.transform.position;
                

                break;
            case EnemyState.Attack:
                if (!PlayerCharacter.Instance.IsAlive)
                    ChangeState(EnemyState.Idle);

                if(enemyAniEvent != null)
                    if (Vector3.Distance(transform.position, PlayerCharacter.Instance.playerModelPos) > attackRange && !enemyAniEvent.IsAttack)
                    {
                        ChangeState(EnemyState.Move);
                    }

                if(bossAniEvent != null)
                {
                    if (Vector3.Distance(transform.position, PlayerCharacter.Instance.playerModelPos) > attackRange && !bossAniEvent.IsPlayerIn)
                    {
                        ChangeState(EnemyState.Move);
                    }
                }

                //navAgent.destination = PlayerCharacter.Instance.transform.position;
                transform.LookAt(PlayerCharacter.Instance.transform);
                transform.eulerAngles = Vector3.up * transform.eulerAngles.y;

                break;
            case EnemyState.Die:
                if (enemyAniEvent != null &&!enemyAniEvent.IsAlive)
                {
                    ChangeState(EnemyState.None);
                }
                break;
            case EnemyState.None:
                Destroy(gameObject, 1f);
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
                
                break;
            case EnemyState.Die:
                RoomEnemyControl.countEnemies--;
                isAlive = false;
                navAgent.isStopped = true;
                GetComponent<Collider>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                animator.SetTrigger("Die");
                break;
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
        if (nowState == EnemyState.Die)
            return;

        healthPoint -= damage;
        if (healthPoint < 0)
        {
            ChangeState(EnemyState.Die);
            lockOnGround.SetActive(false);
            PlaySoundDead();
        }

        else
        {
            animator.SetTrigger("Hit");
            PlaySoundHit();
        }
        
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
